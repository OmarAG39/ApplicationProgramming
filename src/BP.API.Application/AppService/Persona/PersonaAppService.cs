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

    public class PersonaAppService : AsyncCrudAppService<Persona, PersonaDto, long, PagedPersonaResultRequestDto, CreatePersonaDto, PersonaDto>, IPersonaAppService
    {
        private readonly IRepository<Persona, long> _repositoryPersona;
        public PersonaAppService(IRepository<Persona, long> repositoryPersona) : base(repositoryPersona)
        {
            _repositoryPersona = repositoryPersona;

         }
        
        //[AbpAllowAnonymous]
        // para que no sudite el GEtAll  se coloca  lo siguiente
        //[DisableAuditing]
        public override Task<PagedResultDto<PersonaDto>> GetAllAsync(PagedPersonaResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        //[AbpAuthorize("ListClient")]
        public override Task<PersonaDto> CreateAsync(CreatePersonaDto input)
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
