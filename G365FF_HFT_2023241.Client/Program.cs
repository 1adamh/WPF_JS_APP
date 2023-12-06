

using ConsoleTools;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Client;
using System;
using System.Collections.Generic;
using System.Linq;


namespace G365FF_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Read(string entity)
        {
            if (entity == "Taxi")
            {
                Console.Write("Enter taxi id: ");
                int id = int.Parse(Console.ReadLine());
                Taxi t = rest.Get<Taxi>(id, "taxi");
                Console.WriteLine($"{t.TID} {t.Name} {t.RideID}");
            }
            else
            {
                if (entity == "Ride")
                {
                    Console.Write("Enter ride id: ");
                    int id = int.Parse(Console.ReadLine());
                    Ride t = rest.Get<Ride>(id, "ride");
                    Console.WriteLine($"{t.RID} {t.Distance} {t.TaxiId} {t.Cost}");
                }
                else
                {
                    if (entity == "Passenger")
                    {

                        Console.Write("Enter passenger id: ");
                        int id = int.Parse(Console.ReadLine());
                        Passenger t = rest.Get<Passenger>(id, "passenger");
                        Console.WriteLine($"{t.PID} {t.Name} {t.RideID}");
                    }
                }
            }
            Console.ReadKey();

        }

        static void Create(string entity)
        {
            if (entity == "Taxi")
            {
                Console.Write("Enter taxi Name: ");
                string name = Console.ReadLine();
                rest.Post(new Taxi() { Name = name }, "taxi");
            }
            else if (entity == "Passenger")
            {
                Console.Write("Enter passenger Name: ");
                string name = Console.ReadLine();
                rest.Post(new Passenger() { Name = name }, "passenger");
            }
            else if (entity == "Ride")
            {
                Console.Write("Enter ride Name: ");
                int distance = int.Parse(Console.ReadLine());
                rest.Post(new Ride() { Distance = distance }, "taxi");
            }


        }
        static void List(string entity)
        {
            if (entity == "Taxi")
            {
                List<Taxi> taxis = rest.Get<Taxi>("taxi");
                foreach (var item in taxis)
                {
                    Console.WriteLine(item.TID + ": " + item.Name);
                }

            }
            else if (entity == "Passenger")
            {
                List<Passenger> passengers = rest.Get<Passenger>("passenger");
                foreach (var item in passengers)
                {
                    Console.WriteLine(item.PID + ": " + item.Name);
                }
            }
            else if (entity == "Ride")
            {
                List<Ride> rides = rest.Get<Ride>("ride");
                foreach (var item in rides)
                {
                    Console.WriteLine(item.RID + ": " + item.Distance);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Taxi")
            {
                Console.WriteLine("Enter Taxi's id to update");
                int id = int.Parse(Console.ReadLine());
                Taxi one = rest.Get<Taxi>(id, "taxi");
                Console.WriteLine($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "taxi");
            }
            else if (entity == "Passenger")
            {
                Console.WriteLine("Enter Passengers's id to update");
                int id = int.Parse(Console.ReadLine());
                Passenger one = rest.Get<Passenger>(id, "passenger");
                Console.WriteLine($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Passenger");
            }
            else if (entity == "Ride")
            {
                Console.WriteLine("Enter Ride's id to update");
                int id = int.Parse(Console.ReadLine());
                Ride one = rest.Get<Ride>(id, "ride");
                Console.WriteLine($"New name [old: {one.Distance}]: ");
                int distance = int.Parse(Console.ReadLine());
                one.Distance = distance;
                rest.Put(one, "ride");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Taxi")
            {
                Console.Write("Enter Taxi's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "taxi");
            }
            else if (entity == "Passenger")
            {
                Console.Write("Enter Passenger's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "passenger");
            }
            else if (entity == "Ride")
            {
                Console.Write("Enter Ride's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "ride");
            }
        }


        static void AvgDistanceByDriver()
        {
            List<object> list = rest.Get<object>("RideStat/AvgDistanceByDriver");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }



        static void AvgDistanceByPassenger()
        {
            List<object> list = rest.Get<object>("RideStat/AvgDistanceByPassenger");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static void AvgCostByPassenger()
        {
            List<object> list = rest.Get<object>("RideStat/AvgCostByPassenger");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        

        static void AvgDriverRide()
        {
            List<object> list = rest.Get<object>("RideStat/AvgDriverRide");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        
        static void AvgPassByDriver()
        {
            List<object> list = rest.Get<object>("PassengerStat/AvgPassByDriver");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }



        static void Main(string[] args)
        {


            rest = new RestService("http://localhost:12932/", "ride");
            var passengerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Passenger"))
                .Add("Read", () => Read("Passenger"))
                .Add("Create", () => Create("Passenger"))
                .Add("Delete", () => Delete("Passenger"))
                .Add("Update", () => Update("Passenger"))
                .Add("AvgPassByDriver", () => AvgPassByDriver())
                .Add("Exit", ConsoleMenu.Close);

            var rideSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Ride"))
                .Add("Read", () => Read("Ride"))
                .Add("Create", () => Create("Ride"))
                .Add("Delete", () => Delete("Ride"))
                .Add("Update", () => Update("Ride"))
                .Add("AvgDistanceByDriver", () => AvgDistanceByDriver())
                .Add("AvgDistanceByPassenger", () => AvgDistanceByPassenger())
                .Add("AvgCostByPassenger", () => AvgCostByPassenger())
                .Add("AvgDriverRide", () => AvgDriverRide())
                .Add("Exit", ConsoleMenu.Close);

            var taxiSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Taxi"))
                .Add("Read", () => Read("Taxi"))
                .Add("Create", () => Create("Taxi"))
                .Add("Delete", () => Delete("Taxi"))
                .Add("Update", () => Update("Taxi"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Passengers", () => passengerSubMenu.Show())
                .Add("Rides", () => rideSubMenu.Show())
                .Add("Taxis", () => taxiSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }

    }
}
