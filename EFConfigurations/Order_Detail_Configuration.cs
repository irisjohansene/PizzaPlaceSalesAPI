using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Models;
using System.Reflection.Emit;

namespace PizzaPlaceSalesAPI.EFConfigurations
{
    public class Order_Detail_Configuration : IEntityTypeConfiguration<Order_Detail>
    {
        public void Configure(EntityTypeBuilder<Order_Detail> builder)
        {
            builder.HasKey(od => od.Order_Detail_Id);
            builder.HasOne(od => od.Order)
            .WithMany(o => o.Order_Details)
            .HasForeignKey(od => od.Order_Id);

            builder.HasOne(od => od.Pizza)
                .WithMany(p => p.Order_Details)
                .HasForeignKey(od => od.Pizza_Id);
        }
    }
}
