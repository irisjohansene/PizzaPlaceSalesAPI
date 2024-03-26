using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace PizzaPlaceSalesAPI.Dto
{
    public class Pizza_Dto
    {
        [Name("pizza_id")]
        public string Pizza_Id { get; set; }

        [Name("pizza_type_id")]
        public string Pizza_Type_Id { get; set; }

        [Name("size")]
        public string Size { get; set; }

        [Name("price")]
        public decimal Price { get; set; }
    }

    public sealed class Pizza_DtoMap : ClassMap<Pizza_Dto>
    {
        public Pizza_DtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Pizza_Id).Name("pizza_id");
            Map(m => m.Pizza_Type_Id).Name("pizza_type_id");
            Map(m => m.Size).Name("size");
            Map(m => m.Price).Name("price");
        }
    }
}
