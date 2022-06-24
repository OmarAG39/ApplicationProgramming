using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;


namespace BP.API.AppService.Movimiento.Dto

{
    [AutoMap(typeof(BP.API.Entity.Movimientos))]
    public class MovimientosDto : CreateMovimientosDto

    {
        
    }
}
