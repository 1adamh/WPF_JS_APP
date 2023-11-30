

using ConsoleTools;
using G365FF_HFT_2023241.Models;
using MovieDbApp.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G365FF_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        
        static void Create(string entity)
        {
            if (entity== "Taxi")
            {
                Console.Write("Enter taxi Name: ");
                string name = Console.ReadLine();
                rest.Post(new Taxi() { Name = name }, "taxi");
            }
            

        }
        static void List(string entity)
        {
            if (entity == "Taxi")
            {
                List<Taxi> taxis = rest.Get<Taxi>("taxi");
                foreach (var item in taxis) {
                    Console.WriteLine( item.TID+ ": "+ item.Name);
                }

            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity=="Taxi")
            {
                Console.WriteLine("Enter Taxi's id to update" );
                int id= int.Parse(Console.ReadLine());
                Taxi one = rest.Get<Taxi>(id, "taxi");
                Console.WriteLine($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name=name;
                rest.Put(one, "taxi");
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
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:12932/", "ride");
            var passengerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Passenger"))
                .Add("Create", () => Create("Passenger"))
                .Add("Delete", () => Delete("Passenger"))
                .Add("Update", () => Update("Passenger"))
                .Add("Exit", ConsoleMenu.Close);

            var rideSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Ride"))
                .Add("Create", () => Create("Ride"))
                .Add("Delete", () => Delete("Ride"))
                .Add("Update", () => Update("Ride"))
                .Add("Exit", ConsoleMenu.Close);

            var taxiSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Taxi"))
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
