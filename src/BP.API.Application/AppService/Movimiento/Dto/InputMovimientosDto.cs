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
    public class InputMovimientosDto 

    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Identificacion { get; set; }

    }
}
