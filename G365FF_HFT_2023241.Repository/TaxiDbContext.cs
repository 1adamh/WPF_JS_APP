using G365FF_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Repository
{
    public partial class TaxiDbContext:DbContext

    {
     
        public virtual DbSet<Taxi> Taxis {  get; set; }
        public virtual DbSet<Ut> Utak {  get; set; }
        public virtual DbSet<Utas> Utasok {  get; set; }
        


        public TaxiDbContext()
            
        {
            Database.EnsureCreated();
        }
        public TaxiDbContext(DbContextOptions<TaxiDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db");
            base.OnConfiguring(optionsBuilder);
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Ut>()
                .HasOne(t => t.Taxi)
                .WithMany(t=> t.Utak)
                .HasForeignKey(t => t.TaxiId);
            modelBuilder.Entity<Utas>()
                .HasOne(t => t.Ut)
                .WithMany(t => t.Utasok)
                .HasForeignKey(t => t.UtiD);

            var rides = new Ut[]
            {
                new Ut(){ Id = 1, Ar = 1000, Tavolsag = 15 ,TaxiId=2 },
                new Ut(){ Id = 2, Ar = 2000, Tavolsag = 20 , TaxiId=3 },
                new Ut(){ Id = 3, Ar = 1500, Tavolsag = 18,TaxiId=1  },
                new Ut(){ Id = 4, Ar = 10000, Tavolsag = 30 ,TaxiId=5 },
                new Ut(){ Id = 5, Ar = 100, Tavolsag = 2, TaxiId=4  },
                new Ut(){ Id = 6, Ar = 3250, Tavolsag = 21 ,TaxiId=6 },
            };



            var taxis = new Taxi[]
                        {
                new Taxi(){ TId = 1, Name = "Marco Rossi", UtiD= 1 },
                new Taxi(){ TId = 2, Name = "Fiola Attila", UtiD= 3 },
                new Taxi(){ TId = 3, Name = "Szalai Gábor", UtiD= 5 },
                new Taxi(){ TId = 4, Name = "Varga Barnabás", UtiD= 2 },
                new Taxi(){ TId = 5, Name = "Nagy Zsolt", UtiD= 4 },
                new Taxi(){ TId = 6, Name = "Szoboszlai Dominik", UtiD= 6},

                        };


            var passengers = new Utas[]
                        {
                new Utas(){ Id = 1, Name = "Dibusz Dénes", UtiD= 1 },
                new Utas(){ Id = 2, Name = "Kerkez Milos", UtiD= 3 },
                new Utas(){ Id = 3, Name = "Nagy Ádám", UtiD= 3},
                new Utas(){ Id = 4, Name = "Szappanos Péter", UtiD= 5 },
                new Utas(){ Id = 5, Name = "Németh András", UtiD= 2 },
                new Utas(){ Id = 6, Name = "Horváth Krisztofer", UtiD= 2 },
                new Utas(){ Id = 7, Name = "Szalai Attila", UtiD= 2 },
                new Utas(){ Id = 8, Name = "Botka Endre", UtiD= 4 },
                new Utas(){ Id = 9, Name = "Kalmár Zsolt", UtiD= 6 },
                        };

            modelBuilder.Entity<Taxi>().HasData(taxis);
            modelBuilder.Entity<Ut>().HasData(rides);
            modelBuilder.Entity<Utas>().HasData(passengers);












            base.OnModelCreating(modelBuilder);
           
        }
    }
}
