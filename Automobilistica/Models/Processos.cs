﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Models
{
    public partial class Processos
    {
        public Processos()
        {
            Contrato = new HashSet<Contrato>();
            InversePccdproxprocessoNavigation = new HashSet<Processos>();
        }

        [Key]
        [Column("PCCDPROCESSO")]
        public int Pccdprocesso { get; set; }
        [Required]
        [Column("PCNOME")]
        [StringLength(50)]
        [Unicode(false)]
        public string Pcnome { get; set; }
        [Required]
        [Column("PCDESCRICAO")]
        [StringLength(255)]
        [Unicode(false)]
        public string Pcdescricao { get; set; }
        [Column("PCSTATUS")]
        public bool? Pcstatus { get; set; }
        [Column("PCCDPROXPROCESSO")]
        public int? Pccdproxprocesso { get; set; }

        [ForeignKey("Pccdproxprocesso")]
        [InverseProperty("InversePccdproxprocessoNavigation")]
        public virtual Processos PccdproxprocessoNavigation { get; set; }
        [InverseProperty("CtcdprocessoNavigation")]
        public virtual ICollection<Contrato> Contrato { get; set; }
        [InverseProperty("PccdproxprocessoNavigation")]
        public virtual ICollection<Processos> InversePccdproxprocessoNavigation { get; set; }
    }
}