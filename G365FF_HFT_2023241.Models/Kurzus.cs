using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Models
{
    public class Kurzus
    {
        [Key]
        public int KurzusId { get; set; }

        [StringLength(100)]
        public string Kurzusnev {  get; set; }

        public int Kredit {  get; set; }

        public int TanarId { get; set; } //idegen

        [NotMapped]
        public virtual Tanar Tanar { get; set; }

        
    }
}
