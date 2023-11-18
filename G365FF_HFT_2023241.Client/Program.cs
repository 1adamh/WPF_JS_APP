using G365FF_HFT_2023241.Repository;
using System;
using System.Linq;

namespace G365FF_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiDbContext db = new TaxiDbContext();
            var taxis= db.Taxis.ToArray();
            var utasok= db.Utasok.ToArray();
            var utak= db.Utak.ToArray();

            
        }
    }
}
