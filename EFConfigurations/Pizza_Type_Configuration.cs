using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.EFConfigurations
{
    public class Pizza_Type_Configuration : IEntityTypeConfiguration<Pizza_Type>
    {
        public void Configure(EntityTypeBuilder<Pizza_Type> builder)
        {
            builder.HasKey(pt => pt.Pizza_Type_Id);
        }
    }
}
