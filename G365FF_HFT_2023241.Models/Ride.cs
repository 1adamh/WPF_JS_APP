using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Models
{
    public class Ride
    {
      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RID { get; set; }

        public int Cost { get; set; }

        public int Distance { get; set; }

        public int TaxiId {  get; set; }
        [NotMapped]
        public virtual Taxi Taxi { get; set; }

        [NotMapped]
        public virtual List<Passenger> Passengers { get; set; }
        
    }
}
