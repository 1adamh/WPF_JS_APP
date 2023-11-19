using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Models
{
    public class Taxi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int RideID { get; set; }
        
        [NotMapped] 
        public virtual List<Ride> Rides { get; set; }
    }
}
