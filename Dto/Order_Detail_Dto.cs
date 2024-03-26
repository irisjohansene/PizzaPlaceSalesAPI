using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace PizzaPlaceSalesAPI.Dto
{
    public class Order_Detail_Dto
    {
        [Name("order_details_id")]
        public int Order_Detail_Id { get; set; }

        [Name("order_id")]
        public int Order_Id { get; set; }

        [Name("pizza_id")]
        public string Pizza_Id { get; set; }

        [Name("quantity")]
        public int Quantity { get; set; }
    }

    public sealed class Order_Detail_DtoMap : ClassMap<Order_Detail_Dto>
    {
        public Order_Detail_DtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Order_Detail_Id).Name("order_details_id");
            Map(m => m.Order_Id).Name("order_id");
            Map(m => m.Pizza_Id).Name("pizza_id");
            Map(m => m.Quantity).Name("quantity");
        }
    }
}
