using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using BP.API.Modelo;

namespace BP.API.Entity
{
    public class Cliente : Persona

    {
       
        [Required]
        public string Contrasena { get; set; }
       
        [Required]
        public bool Estado { get; set; }

        //[ForeignKey("Persona")]   //Tabla Persona
        //[Required]
        //public long PersonaId { get; set; }   // Id tabla Persona
        //public Persona Persona { get; set; }  //Entidad Persona




    }
}
