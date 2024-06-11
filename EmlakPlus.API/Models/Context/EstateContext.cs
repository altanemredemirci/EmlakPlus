using EmlakPlus.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmlakPlus.API.Models.Context
{
    public class EstateContext:DbContext
    {
        public EstateContext(DbContextOptions<EstateContext> options):base(options)
        {
            
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
        public DbSet<Image> Images { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}
