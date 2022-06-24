using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
//using Abp.Auditing;
//using Abp.Authorization;
using Abp.Domain.Repositories;
using BP.API.Dto;
using BP.API.Entity;

namespace BP.API.Service
{  //[AbpAuthorize]
    // para que audite todos los CRUD
   // [Audited] 

    public class CuentaAppService : AsyncCrudAppService<Cuenta, CuentaDto, long, PagedCuentaResultRequestDto, CreateCuentaDto, CuentaDto>, ICuentaAppService
    {
        private readonly IRepository<Cuenta, long> _repositoryCuenta;
        public CuentaAppService(IRepository<Cuenta, long> repositoryCuenta) : base(repositoryCuenta)
        {
            _repositoryCuenta = repositoryCuenta;

         }
        
        //[AbpAllowAnonymous]
        // para que no sudite el GEtAll  se coloca  lo siguiente
        //[DisableAuditing]
        public override Task<PagedResultDto<CuentaDto>> GetAllAsync(PagedCuentaResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        //[AbpAuthorize("ListClient")]
        public override Task<CuentaDto> CreateAsync(CreateCuentaDto input)
        {
            return base.CreateAsync(input);
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
