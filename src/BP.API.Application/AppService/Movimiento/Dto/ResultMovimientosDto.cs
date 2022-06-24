using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BP.API.Entity;

namespace BP.API.AppService.Movimiento.Dto
{
    [AutoMap(typeof(BP.API.Entity.Movimientos))]
    public class ResultMovimientosDto : EntityDto<long>

    {
        [Required]
        public DateTime? Fecha { get; set; }
        [Required]
        public string  Cliente { get; set; } 
        [Required]
        public string NumeroCuenta { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public decimal SaldoInicial { get; set; }
        [Required]
        public bool Estado { get; set; }   // Id tabla Cuenta
        [Required]
        public decimal Movimiento { get; set; }   // Id tabla Cuenta
        [Required]
        public decimal SaldoDisponible { get; set; }   // Id tabla Cuenta

    }
}
