using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Abp.EntityFrameworkCore.Repositories;

using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using Abp.Runtime.Validation;

using Abp.EntityFramework;
using BP.API.Dto;
using BP.API.AppService.Movimiento;
using BP.API.AppService.Movimiento.Dto;
using Abp.Application.Services.Dto;
using Abp.Application.Services;
using BP.API.Entity;
using BP.API;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Xml;
using System.Reflection;

namespace BP.Notification.Business
{
    public class MovimientosBusinnes : DomainService
    {


        private readonly IRepository<Movimientos, long> _repositoryMovimientos;
        private readonly IRepository<Cliente, long> _cliente;
        private readonly IRepository<Cuenta, long> _repositoryCuenta;




        public MovimientosBusinnes(IRepository<Movimientos, long> movimientos, IRepository<Cliente, long> cliente,
            IRepository<Cuenta, long> cuentas)
        {
            _repositoryMovimientos = movimientos;
            _cliente = cliente;
            _repositoryCuenta = cuentas;
        }


        public List<ResultMovimientosDto> GetAllbyFilterMovimientos(InputMovimientosDto input)
        {


            List<ResultMovimientosDto> resultadoMovimiento = new List<ResultMovimientosDto>();


            var movimiento = _repositoryMovimientos.GetAll().Where(x => (x.Fecha.Value >= input.FechaInicio && x.Fecha.Value <= input.FechaFin &&
                                                                            x.Cuenta.Cliente.Identificacion.CompareTo(input.Identificacion) == 0));

            var MovimientoEntityDtoList = movimiento
            .Select(fila => new ResultMovimientosDto
            {
                Fecha = fila.Fecha,
                Cliente = fila.Cuenta.Cliente.Nombre,
                NumeroCuenta = fila.Cuenta.NumeroCuenta,
                Tipo = fila.Cuenta.TipoCuenta,
                SaldoInicial = fila.Cuenta.SaldoInicial,
                Estado = fila.Cuenta.Estado,
                Movimiento = fila.Valor,
                SaldoDisponible = fila.Saldo
            }

            ).ToList();

            return MovimientoEntityDtoList.ToList();
        }


        public CreateMovimientosDto CreateAsync(CreateMovimientosDto input, out string msg )
        {
            string strMensaje = "Saldo no disponible";
            int intCupoDiario = 1000;
            decimal decSumatoriaSaldo = 0;
            DateTime dateTimeHoy = DateTime.Now;
            msg = string.Empty;

            var resultado = _repositoryMovimientos.GetAll().Where(x =>
                                                 x.Cuenta.NumeroCuenta.Trim().Equals(input.NumeroCuenta.Trim())).Take(1).OrderByDescending(y => y.CuentaId);

            //var resultado = _repositoryMovimientos.GetAll().Where(x =>
            //                                    x.CuentaId == input.CuentaId).Take(1).OrderByDescending(y => y.CuentaId);


            if (resultado.Count() == 0)
            {
                //var objCuenta = _repositoryCuenta.GetAll().Where(x =>
                //                                x.Id == input.CuentaId).Take(1).OrderByDescending(y => y.Id);

                var objCuenta = _repositoryCuenta.GetAll().Where(x =>
                                             x.NumeroCuenta.Trim().Equals(input.NumeroCuenta.Trim())).Take(1).OrderByDescending(y => y.Id);


                Cuenta cuentaCliente = new Cuenta();
                cuentaCliente = (Cuenta)objCuenta.FirstOrDefault();

                input.Saldo = cuentaCliente.SaldoInicial;
                input.Valor = 0;
                input.CuentaId = cuentaCliente.Id;
            }
            else
            {
                BP.API.Entity.Movimientos movimientoCliente = new BP.API.Entity.Movimientos();
                movimientoCliente = (BP.API.Entity.Movimientos)resultado.FirstOrDefault();
                if (input.TipoMovimiento.CompareTo("Debito") == 0)
                {

                    if (movimientoCliente.Saldo == 0 || (input.Valor > movimientoCliente.Saldo))
                    {
                        //Desplegar el msg "Saldo no Disponible"
                        Console.Write("Saldo no Disponible");
                        string clearMessage = "Saldo no Disponible";
                        msg = clearMessage;

                        Logger.Debug(clearMessage);
                        return null;
                    }
                    else
                    {

                        //var decSumatoriaRetiro = _repositoryMovimientos.GetAll().Where(x => x.Fecha.Value.Year == dateTimeHoy.Year &&
                        //                        x.Fecha.Value.Month == dateTimeHoy.Month && x.Fecha.Value.Day == dateTimeHoy.Day &&
                        //                        string.Compare(x.TipoMovimiento, "Debito") == 0 &&
                        //                        x.CuentaId == input.CuentaId).Sum(y => y.Valor);

                        var decSumatoriaRetiro = _repositoryMovimientos.GetAll().Where(x => x.Fecha.Value.Year == dateTimeHoy.Year &&
                                                x.Fecha.Value.Month == dateTimeHoy.Month && x.Fecha.Value.Day == dateTimeHoy.Day &&
                                                string.Compare(x.TipoMovimiento, "Debito") == 0 &&
                                                x.Cuenta.NumeroCuenta.Trim().Equals(input.NumeroCuenta.Trim())).Sum(y => y.Valor);


                        if (decSumatoriaRetiro > intCupoDiario)
                        {
                            Console.Write("Cupo Diario Excedido");
                            string clearMessage = "Saldo no Disponible";
                            msg = clearMessage;
                            Logger.Debug(clearMessage);
                            return null;

                        }
                        else
                        {
                            input.Saldo = movimientoCliente.Saldo - input.Valor;
                            input.CuentaId = movimientoCliente.CuentaId;
                        }
                    }
                }

                else
                {
                    input.Saldo = movimientoCliente.Saldo + input.Valor;
                }
            }

            return input;
        }
    }




}



