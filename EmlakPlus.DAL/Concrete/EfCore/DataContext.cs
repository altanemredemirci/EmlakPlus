using EmlakPlus.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.DAL.Concrete.EfCore
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-HOCAPC\\SQLDERS; Database=EmlakPlus; Integrated Security=true; TrustServerCertificate=True;");
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<WhoWeAre> WhoWeAres { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Mail> Mails { get; set; }
    }
}
