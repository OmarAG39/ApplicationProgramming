using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace BP.API.Entity
{
    public class Movimientos : Entity<long>

    {

        // propiedades de Movimientos

        [Required]
        public DateTime? Fecha { get; set; }
        
        [Required]
        public string TipoMovimiento { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public decimal Saldo { get; set; }

        [ForeignKey("Cuenta")]   //Tabla Cuenta
        [Required]
        public long CuentaId { get; set; }   // Id tabla Cuenta
        public Cuenta Cuenta { get; set; }  //Entidad Cuenta



    }
}
