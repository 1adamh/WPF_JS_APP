using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G365FF_HFT_2023241.Models
{
    public class Hallgato
    {
        [Key]
        public int NeptunKod { get; set; }
        [StringLength(100)]
        public string HallgatoNev { get; set; }

        public int kurzusId {  get; set; } // idegen

        [NotMapped]
        public virtual List<Kurzus> Kurzusok { get; set; }



    }
}
