using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.EFConfigurations;
using PizzaPlaceSalesAPI.Models;
using System.Drawing;
using System.Reflection.Metadata;

namespace PizzaPlaceSalesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Pizza_Type> Pizza_Types { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Order_Detail>(new Order_Detail_Configuration());
            modelBuilder.ApplyConfiguration<Order>(new Order_Configuration());
            modelBuilder.ApplyConfiguration<Pizza>(new Pizza_Configuration());
            modelBuilder.ApplyConfiguration<Pizza_Type>(new Pizza_Type_Configuration());
        }
    }
}
