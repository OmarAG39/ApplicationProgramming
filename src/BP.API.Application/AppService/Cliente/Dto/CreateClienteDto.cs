using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BP.API.Entity;

namespace BP.API.Dto
{
    [AutoMap(typeof(Cliente))]
    public class CreateClienteDto : CreatePersonaDto
    
    {
       
        [Required]
        public string Contrasena { get; set; }

        [Required]
        public bool Estado { get; set; }


    }
}
