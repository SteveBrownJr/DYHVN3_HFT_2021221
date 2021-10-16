using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DYHVN3_HFT_2021221.Models;


namespace DYHVN3_HFT_2021221.Data
{
    public class PCDbContext : DbContext 
    {
        private string ConnectionString { get { return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True"; } }
        public virtual DbSet<Distributor> Distributors{ get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Modell> Modells { get; set; }
        public PCDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder) {
            if (!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder
                              .UseLazyLoadingProxies()
                              .UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modell>(entity =>
            {
                entity
                .HasOne(modell => modell.Manufacturer)
                .WithMany(manufacturer=> manufacturer.Modells)
                .HasForeignKey(car => car.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity
                .HasOne(manufacturer => manufacturer.Distributor)
                .WithMany(distributor=> distributor.Manufacturers)
                .HasForeignKey(manufacturer => manufacturer.DistributorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Distributor PCX = new Distributor() { Distributor_Id = 1, Name = "PCX", Country = "Hungary" };
            Distributor EBay = new Distributor() { Distributor_Id = 2, Name = "EBay", Country = "America" };

            Manufacturer Intel = new Manufacturer() { Manufacturer_Id = 1, Name = "Intel", colour = "Blue", DistributorId = PCX.Distributor_Id };
            Manufacturer AMD = new Manufacturer() { Manufacturer_Id = 2, Name = "AMD", colour = "Red", DistributorId = PCX.Distributor_Id };
            Manufacturer ARM = new Manufacturer() { Manufacturer_Id = 3, Name = "ARM", colour = "Black", DistributorId = EBay.Distributor_Id };

            Modell R51600X = new Modell() {Modell_Id=1, Name="1600X", ClockSpeed=3600, Family="Ryzen", HyperThreading = true, Cores=6,ManufacturerId=AMD.Manufacturer_Id  };
            Modell R51800X = new Modell() { Modell_Id = 2, Name = "1800X", ClockSpeed = 3700, Family = "Ryzen", HyperThreading = true, Cores = 8, ManufacturerId = AMD.Manufacturer_Id };

            Modell i77700k = new Modell() { Modell_Id = 3, Name = "i7 7700k", ClockSpeed = 4100, Family = "Core", Cores = 4,HyperThreading=true, ManufacturerId = Intel.Manufacturer_Id };
            Modell i99950k = new Modell() { Modell_Id = 4, Name = "i9 99950k", ClockSpeed = 4000, Family = "Core", Cores = 8, HyperThreading = true, ManufacturerId = Intel.Manufacturer_Id };

            modelBuilder.Entity<Distributor>().HasData(PCX, EBay);
            modelBuilder.Entity<Manufacturer>().HasData(Intel, AMD,ARM);
            modelBuilder.Entity<Modell>().HasData(R51600X,R51800X,i77700k,i99950k);
        }
    }
}
