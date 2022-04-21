using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYHVN3_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;


namespace DYHVN3_HFT_2021221.Data
{
    public class TrainDbContext : DbContext
    {
        private string ConnectionString { get { return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True"; } }

        public virtual DbSet<Locomotive> Locomotives { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Wagon> Wagons {get;set;}

        public TrainDbContext()
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
            modelBuilder.Entity<Station>(entitiy =>
            {
                entitiy
                .HasOne(station => station.locomotive)
                .WithMany(locomotive => locomotive.Stations)
                .HasForeignKey(station => station.Locomotive_Id)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Wagon>(entity =>
            {
                entity
                .HasOne(wagon => wagon.locomotive)
                .WithMany(locomotive => locomotive.Wagons)
                .HasForeignKey(wagon => wagon.Locomotive_Id)
                .OnDelete(DeleteBehavior.Restrict);
            });


            List<Locomotive> locomotives = new List<Locomotive>();
            locomotives.Add(new Locomotive() { Name = "Günhild", Locomotive_Id = 1, Staff = 1, Type = "NoHab", Starting_Torque = 292 });
            locomotives.Add(new Locomotive() { Name = "Fecske", Locomotive_Id = 2, Staff = 1, Type = "V43", Starting_Torque = 270 }); 
            locomotives.Add(new Locomotive() { Name = "Repcebika", Locomotive_Id = 3, Staff = 2, Type = "Taurus", Starting_Torque = 300 });
            locomotives.Add(new Locomotive() { Name = "Dórémí", Locomotive_Id = 4, Staff = 2, Type = "Taurus", Starting_Torque = 300 });
            locomotives.Add(new Locomotive() { Name = "Kisleó", Locomotive_Id = 5, Staff = 3, Type = "V41", Starting_Torque = 230 });
            locomotives.Add(new Locomotive() { Name = "Papagáj", Locomotive_Id = 6, Staff = 1, Type = "V43", Starting_Torque = 270 }); 

            List<Wagon> addable_wagons = new List<Wagon>() {
            new Wagon() { Locomotive_Id = 1, Quantity = 60, Wagon_Id = 1 },
            new Wagon() { Locomotive_Id = 1, Quantity = 60, Wagon_Id = 2 },
            new Wagon() { Locomotive_Id = 1, Quantity = 60, Wagon_Id = 3 },
            new Wagon() { Locomotive_Id = 1, Quantity = 60, Wagon_Id = 4 },

            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 5, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 6, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 7, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 8, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 9, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 10, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 11, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 12, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 13, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 14, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 15, CargoType = Cargo_Type.Tank },
            new Wagon() { Locomotive_Id = 3, Quantity = 1000, Wagon_Id = 16, CargoType = Cargo_Type.Tank },

            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 17 },
            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 18 },
            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 19 },
            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 20 },
            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 21 },
            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 22 },
            new Wagon() { CargoType = Cargo_Type.Hopper, Locomotive_Id = 4, Quantity = 1000, Wagon_Id = 23 },

            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 24 },
            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 25 },
            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 26 },
            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 27 },
            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 28 },
            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 29 },
            new Wagon() { Locomotive_Id = 2, CargoType = Cargo_Type.Mail, Quantity = 10000, Wagon_Id = 30 },
        };
            for (int i = 0; i < addable_wagons.Count(); i++)
            {
                locomotives[addable_wagons[i].Locomotive_Id - 1].load += addable_wagons[i].Quantity;
            }
            modelBuilder.Entity<Locomotive>().HasData(locomotives[0], locomotives[1], locomotives[2], locomotives[3], locomotives[4]);
            modelBuilder.Entity<Wagon>().HasData(addable_wagons);

            List<Station> addable_stations = new List<Station>() {
            new Station() { Station_Id = 1, Name = "Budapest", x_cordinate = 0, y_cordinate = 0, Locomotive_Id = 2},
            new Station() { Station_Id = 2, Name = "Kelebia", x_cordinate = 2, y_cordinate = 100, Locomotive_Id = 2 },

            new Station() { Station_Id = 3, Name = "Miskolc", x_cordinate = 80, y_cordinate = 9,  Locomotive_Id = 1 },
            new Station() { Station_Id = 4, Name = "Tatabanya", x_cordinate = -30, y_cordinate = -10, Locomotive_Id = 1 },

            new Station() { Station_Id = 5, Name = "Szombathely", x_cordinate = -20, y_cordinate = -100, Locomotive_Id = 3 },
            new Station() { Station_Id = 6, Name = "Nyiregyhaza", x_cordinate = -30, y_cordinate = 120, Locomotive_Id = 3 },

            new Station() { Station_Id = 7, Name = "Szolnok", x_cordinate = 30, y_cordinate = -60, Locomotive_Id = 4 },
            new Station() { Station_Id = 8, Name = "Szeged", x_cordinate = 20, y_cordinate = -90, Locomotive_Id = 4 },

            //new Station() { Station_Id = 9, Name = "Dunaujvaros", x_cordinate = 5, y_cordinate = -65, Locomotive_Id = 5 },
            };

            modelBuilder.Entity<Station>().HasData(addable_stations);
        }
    }
}
