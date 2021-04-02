using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Entity.Entities
{
    [Table("company")]
    public class Company : BaseEntity
    {
        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string CompanySlug { get; set; }

        public string CompanyLogoName { get; set; }
    }
}