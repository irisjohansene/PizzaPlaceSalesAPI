using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.EFConfigurations
{
    public class Order_Configuration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Order_Id);
            builder.Property(o => o.Date)
            .HasColumnType("date");
        }
    }
}