using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace PizzaPlaceSalesAPI.Dto
{
    public class Pizza_Type_Dto
    {
        [Name("pizza_type_id")]
        public string Pizza_Type_Id { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("category")]
        public string Category { get; set; }

        [Name("ingredients")]
        public string Ingredients { get; set; }
    }

    public sealed class Pizza_Type_DtoMap : ClassMap<Pizza_Type_Dto>
    {
        public Pizza_Type_DtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Pizza_Type_Id).Name("pizza_type_id");
            Map(m => m.Name).Name("name");
            Map(m => m.Category).Name("category");
            Map(m => m.Ingredients).Name("ingredients");
        }
    }
}
