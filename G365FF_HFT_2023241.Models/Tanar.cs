using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Models
{
    public class Tanar
    {
        [Key]
        public int TanarId { get; set; }

        [StringLength(100)]
        public string TanarNev {  get; set; }

        public int KurzusId { get; set; } //idegen

        [NotMapped]
        public virtual List<Kurzus> Kurzusok { get; set;}
    }
}
