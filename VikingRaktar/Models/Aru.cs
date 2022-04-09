using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VikingRaktar.Models
{
    public class Aru
    {
        public int Id { get; set; }
        [Display(Name = "Megnevezés")]
        [StringLength(60)]
        public string Megnevezes { get; set; }

        [Display(Name = "Beszállító")]
        [StringLength(60)]
        public string Beszallito { get; set; }

        [Display(Name = "Beszerzési Ár")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ar { get; set; }
    }
}
