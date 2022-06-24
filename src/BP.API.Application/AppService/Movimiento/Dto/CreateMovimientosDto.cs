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
    public class CreateMovimientosDto : EntityDto<long>

    {
        [Required]
        public DateTime? Fecha { get; set; }
        [Required]
        public string TipoMovimiento { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }

        public long CuentaId { get; set; }   // Id tabla Cuenta

    }
}
