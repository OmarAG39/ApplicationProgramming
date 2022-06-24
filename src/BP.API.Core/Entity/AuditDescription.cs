using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BP.API.Entity
{
    public class AuditDescription : Entity<long>
    {
        [Required]
        [StringLength(100)]
        public string NameService { get; set; }

        [Required]
        [StringLength(300)]
        public string Value { get; set; }
    }
}
