using G365FF_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Repository.Data
{
    public partial class TaxiDbContext : DbContext

    {

        public virtual DbSet<Taxi> Taxis { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }



        public TaxiDbContext()

        {
            Database.EnsureCreated();
        }
        public TaxiDbContext(DbContextOptions<TaxiDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ride>()
                .HasOne(t => t.Taxi)
                .WithMany(t => t.Rides)
                .HasForeignKey(t => t.TaxiId);
            modelBuilder.Entity<Passenger>()
                .HasOne(t => t.Ride)
                .WithMany(t => t.Passengers)
                .HasForeignKey(t => t.RideID);

            var rides = new Ride[]
            {
                new Ride(){ RID = 1, Cost = 1000, Distance = 15 ,TaxiId=2 },
                new Ride(){ RID = 2, Cost = 2000, Distance = 20 , TaxiId=3 },
                new Ride(){ RID = 3, Cost = 1500, Distance = 18,TaxiId=1  },
                new Ride(){ RID = 4, Cost = 10000, Distance = 30 ,TaxiId=5 },
                new Ride(){ RID = 5, Cost = 100, Distance = 2, TaxiId=4  },
                new Ride(){ RID = 6, Cost = 3250, Distance = 21 ,TaxiId=6 },
            };



            var taxis = new Taxi[]
                        {
                new Taxi(){ TID = 1, Name = "Marco Rossi", RideID= 1 },
                new Taxi(){ TID = 2, Name = "Fiola Attila", RideID= 3 },
                new Taxi(){ TID = 3, Name = "Szalai Gábor", RideID= 5 },
                new Taxi(){ TID = 4, Name = "Varga Barnabás", RideID= 2 },
                new Taxi(){ TID = 5, Name = "Nagy Zsolt", RideID= 4 },
                new Taxi(){ TID = 6, Name = "Szoboszlai Dominik", RideID= 6},

                        };

            var passengers = new Passenger[]
                        {
                new Passenger(){ PID = 1, Name = "Dibusz Dénes", RideID= 1 },
                new Passenger(){ PID = 2, Name = "Kerkez Milos", RideID= 3 },
                new Passenger(){ PID = 3, Name = "Nagy Ádám", RideID= 3},
                new Passenger(){ PID = 4, Name = "Szappanos Péter", RideID= 5 },
                new Passenger(){ PID = 5, Name = "Németh András", RideID= 2 },
                new Passenger(){ PID = 6, Name = "Horváth Krisztofer", RideID= 2 },
                new Passenger(){ PID = 7, Name = "Szalai Attila", RideID= 2 },
                new Passenger(){ PID = 8, Name = "Botka Endre", RideID= 4 },
                new Passenger(){ PID = 9, Name = "Kalmár Zsolt", RideID= 6 },
                        };

            modelBuilder.Entity<Taxi>().HasData(taxis);
            modelBuilder.Entity<Ride>().HasData(rides);
            modelBuilder.Entity<Passenger>().HasData(passengers);

            base.OnModelCreating(modelBuilder);

        }
    }
}
