using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BP.API.Entity;

namespace BP.API.Dto

{
    [AutoMap(typeof(Persona))]
    public class PersonaDto : CreatePersonaDto
    {
        
    }
}
