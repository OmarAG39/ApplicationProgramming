using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace BP.API.Entity
{
    public class Cuenta : Entity<long>
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

        [ForeignKey("Cliente")]   //Tabla Cliente
        [Required]
        public long ClienteId { get; set; }   // Id tabla Cliente
        public Cliente Cliente { get; set; }  //Entidad Cliente


        //Referens referencias Cliente
       

    }
}
