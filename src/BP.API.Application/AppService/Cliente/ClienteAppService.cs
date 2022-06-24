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

    public class ClienteAppService : AsyncCrudAppService<Cliente, ClienteDto, long, PagedClienteResultRequestDto, CreateClienteDto, ClienteDto>, IClienteAppService
    {
        private readonly IRepository<Cliente, long> _repositoryCliente;
        public ClienteAppService(IRepository<Cliente, long> repositoryCliente) : base(repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;

         }
        
        //[AbpAllowAnonymous]
        // para que no sudite el GEtAll  se coloca  lo siguiente
        //[DisableAuditing]
        public override Task<PagedResultDto<ClienteDto>> GetAllAsync(PagedClienteResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        //[AbpAuthorize("ListClient")]
        public override Task<ClienteDto> CreateAsync(CreateClienteDto input)
        {
            return base.CreateAsync(input);
        }

        

    }
}
