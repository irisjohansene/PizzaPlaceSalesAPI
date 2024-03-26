using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.EFConfigurations
{
    public class Pizza_Configuration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(p => p.Pizza_Id);
            builder.Property(p => p.Price).HasColumnType("decimal(2,2)");

            builder.HasOne(p => p.Pizza_Type)
            .WithMany(pt => pt.Pizzas)
            .HasForeignKey(p => p.Pizza_Type_Id);
        }
    }
}
