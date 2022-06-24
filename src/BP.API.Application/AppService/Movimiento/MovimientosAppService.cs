using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BP.API.AppService.Movimiento;
using BP.API.Entity;
using BP.API.AppService.Movimiento.Dto;
using AutoMapper;
using BP.Notification.Business;
using Abp.Authorization;
using System.Linq;


namespace BP.API.AppService.Movimiento
{  //[AbpAuthorize]
   // para que audite todos los CRUD
   // [Audited] 

    public class MovimientosAppService : AsyncCrudAppService<BP.API.Entity.Movimientos, MovimientosDto, long, PagedMovimientosResultRequestDto, CreateMovimientosDto, MovimientosDto>, IMovimientosAppService
    {
        //private readonly IRepository<BP.API.Entity.Movimientos, long> _repositoryMovimientos;
        //private readonly IRepository<BP.API.Entity.Cuenta, long> _repositoryCuenta;
        private readonly IRepository<BP.API.Entity.Cuenta, long> _repositoryCuenta;

        private readonly IRepository<BP.API.Entity.Movimientos, long> _repositoryMovimientos;
        private readonly MovimientosBusinnes _movimientosManager;



        //public MovimientosAppService(IRepository<BP.API.Entity.Movimientos, long> repositoryMovimientos, IRepository<Cuenta, long> repositoryCuenta) : base(repositoryMovimientos)
        //{
        //    _repositoryMovimientos = repositoryMovimientos;
        //    _repositoryCuenta = repositoryCuenta;

        //}
        public MovimientosAppService(IRepository<BP.API.Entity.Movimientos, long> repository, MovimientosBusinnes movimientoManager, IRepository<Cuenta, long> repositoryCuenta) : base(repository)

        {
            _repositoryMovimientos = repository;
            _movimientosManager = movimientoManager;
            _repositoryCuenta = repositoryCuenta;
        }




        //[AbpAllowAnonymous]
        // para que no sudite el GEtAll  se coloca  lo siguiente
        //[DisableAuditing]
        public override Task<PagedResultDto<MovimientosDto>> GetAllAsync(PagedMovimientosResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        //public override Task<MovimientosDto> CreateAsync(CreateMovimientosDto input)
        //{
        //    string strMensaje = "Saldo no disponible";
        //    int intCupoDiario = 1000;
        //    decimal decSumatoriaSaldo = 0;
        //    //decimal decSumatoriaRetiro = 0;
        //    //string strHoy = DateTime.Now.ToShortDateString();
        //    DateTime dateTimeHoy = DateTime.Now;



        //    var resultado = _repositoryMovimientos.GetAll().Where(x =>
        //                                         x.CuentaId == input.CuentaId).Take(1).OrderByDescending(y => y.CuentaId);



        //    //Select(z=>z.Saldo);

        //    if (resultado.Count() == 0)
        //    {
        //        var objCuenta = _repositoryCuenta.GetAll().Where(x =>
        //                                        x.Id == input.CuentaId).Take(1).OrderByDescending(y => y.Id);
        //        Cuenta cuentaCliente = new Cuenta();
        //        cuentaCliente = (Cuenta)objCuenta.FirstOrDefault();

        //        input.Saldo = cuentaCliente.SaldoInicial;
        //        input.Valor = 0;
        //    }
        //    else
        //    {
        //        BP.API.Entity.Movimientos movimientoCliente = new BP.API.Entity.Movimientos();
        //        movimientoCliente = (BP.API.Entity.Movimientos)resultado.FirstOrDefault();
        //        if (input.TipoMovimiento.CompareTo("Debito") == 0)
        //        {

        //            if (movimientoCliente.Saldo == 0 || ( input.Valor > movimientoCliente.Saldo ) )
        //            {
        //                //Desplegar el msg "Saldo no Disponible"
        //                Console.Write("Saldo no Disponible");
        //                return null;
        //            }
        //            else
        //            {

        //                var decSumatoriaRetiro = _repositoryMovimientos.GetAll().Where(x => x.Fecha.Value.Year== dateTimeHoy.Year  &&
        //                                        x.Fecha.Value.Month == dateTimeHoy.Month && x.Fecha.Value.Day == dateTimeHoy.Day &&
        //                                        string.Compare(x.TipoMovimiento, "Debito") == 0 &&
        //                                        x.CuentaId == input.CuentaId).Sum(y => y.Valor);

        //                if (decSumatoriaRetiro > intCupoDiario)
        //                {
        //                    Console.Write("Cupo Diario Excedido");
        //                    return null;

        //                }
        //                else
        //                {
        //                    input.Saldo = movimientoCliente.Saldo - input.Valor;
        //                }
        //            }
        //        }

        //        else
        //        {
        //            input.Saldo = movimientoCliente.Saldo + input.Valor;
        //        }



        //    }






        //    return base.CreateAsync(input);
        //}

        public override Task<MovimientosDto> CreateAsync(CreateMovimientosDto input)
        {
            
            CreateMovimientosDto movimiento = _movimientosManager.CreateAsync(input,  out string msg);
            if (movimiento!=null)
            {
                
                
                
                return base.CreateAsync(movimiento);
            }
            else
            {
                throw new Abp.UI.UserFriendlyException(-1, msg);
            }
           
        }

        public async Task<List<ResultMovimientosDto>> GetAllbyFilterMovimientos(InputMovimientosDto input)
        {
            List<ResultMovimientosDto> movimiento = _movimientosManager.GetAllbyFilterMovimientos(input);
            return movimiento;
        }


       
        Task<PagedResultDto<MovimientosDto>> IAsyncCrudAppService<MovimientosDto, long, ResultMovimientosDto, CreateMovimientosDto, MovimientosDto, EntityDto<long>, EntityDto<long>>.GetAllAsync(ResultMovimientosDto input)
        {
            throw new NotImplementedException();
        }

        Task<MovimientosDto> IAsyncCrudAppService<MovimientosDto, long, ResultMovimientosDto, CreateMovimientosDto, MovimientosDto, EntityDto<long>, EntityDto<long>>.CreateAsync(CreateMovimientosDto input)
        {
            throw new NotImplementedException();
        }

        Task<MovimientosDto> IAsyncCrudAppService<MovimientosDto, long, ResultMovimientosDto, CreateMovimientosDto, MovimientosDto, EntityDto<long>, EntityDto<long>>.UpdateAsync(MovimientosDto input)
        {
            throw new NotImplementedException();
        }

        Task IAsyncCrudAppService<MovimientosDto, long, ResultMovimientosDto, CreateMovimientosDto, MovimientosDto, EntityDto<long>, EntityDto<long>>.DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        //public List<ComboboxClientDto> GetAllCombo()
        //{
        //    //Get entities
        //    var ClientEntityList = _repositoryClient.GetAllList(Client => Client.IsActive == true); 

        //    var ClientEntityDtoList = ClientEntityList

        //    .Select(cliente => new ComboboxClientDto
        //    {
        //        Id = cliente.Id,
        //        BusinessName = cliente.BusinessName,
        //    }

        //    ).ToList();
        //    return ClientEntityDtoList.ToList();

        //}

    }
}
