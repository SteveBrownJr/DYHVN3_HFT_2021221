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
        public virtual DbSet<Motherboard> Motherboards{ get; set; }
        public virtual DbSet<CPU> CPUs { get; set; }
        public virtual DbSet<RAM> RAMs { get; set; }
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

    }
}
