using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Models
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int RideID {  get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Ride Ride { get; set; }

        
    }
}
