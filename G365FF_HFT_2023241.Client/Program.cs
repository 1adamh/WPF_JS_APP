
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


            var q1 = rideLogic.AvgDistanceByDriver();
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }

            var q2 = rideLogic.AvgDistanceByPassenger();
            foreach (var item in q2)
            {
                Console.WriteLine( item);
            }

            var q3 = rideLogic.AvgCostByPassenger();
            foreach (var item in q3)
            {
                Console.WriteLine(item);
            }

            var q4 = rideLogic.AvgDistanceByDriver();
            foreach (var item in q4)
            {
                Console.WriteLine(item);
            }


            var q5 = rideLogic.LongestDistanceDriver();
            Console.WriteLine(q5);





        }
    }
}
