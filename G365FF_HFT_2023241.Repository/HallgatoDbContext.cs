using G365FF_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace G365FF_HFT_2023241.Repository
{
    public class HallgatoDbContext:DbContext

    {
        public DbSet<Hallgato> Hallgatok {  get; set; }
        public DbSet<Tanar> Tanarok { get; set; }

        public DbSet<Kurzus> Kurzusok { get; set;}


        public HallgatoDbContext()
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
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
