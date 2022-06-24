using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BP.API.Entity;

namespace BP.API.Dto
{
    [AutoMap(typeof(Cuenta))]
    public class CreateCuentaDto : EntityDto<long>

    {
        [Required]
        public string NumeroCuenta { get; set; }
        // propiedades de Cuenta
        [Required]
        public string TipoCuenta { get; set; }
        [Required]
        public decimal SaldoInicial { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public long ClienteId { get; set; }   // Id tabla Cliente
       
    }
}
