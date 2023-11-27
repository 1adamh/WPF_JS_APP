
using G365FF_HFT_2023241.Logic.Class;
using G365FF_HFT_2023241.Repository.Class;
using G365FF_HFT_2023241.Repository.Data;
using System;
using System.Linq;

namespace G365FF_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiDbContext db = new TaxiDbContext();
            var taxis = db.Taxis.ToArray();
            var utasok = db.Passengers.ToArray();
            var utak = db.Rides.ToArray();


            TaxiRepo taxiRepo = new TaxiRepo(db);
            RideRepo rideRepo = new RideRepo(db);
            PassengerRepo passengerRepo  = new PassengerRepo(db);
            
            RideLogic rideLogic = new RideLogic(rideRepo,taxiRepo, passengerRepo);

            var q2 = rideLogic.AvgDistanceByPassenger();
            foreach (var item in q2)
            {
                Console.WriteLine( item);
            }

            



        }
    }
}
