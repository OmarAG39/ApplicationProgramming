using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BP.API.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BP.API.AppService.Movimiento.Dto;

namespace BP.API.AppService.Movimiento
{
    public interface IMovimientosAppService : IAsyncCrudAppService<MovimientosDto, long, ResultMovimientosDto, CreateMovimientosDto, MovimientosDto>
    {
          Task<List<ResultMovimientosDto>> GetAllbyFilterMovimientos(InputMovimientosDto input);
    }

}
