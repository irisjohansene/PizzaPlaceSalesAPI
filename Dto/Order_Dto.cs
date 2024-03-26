using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace PizzaPlaceSalesAPI.Dto
{
    public class Order_Dto
    {
        [Name("order_id")]
        public int order_id { get; set; }

        [Name("date")]
        public DateTime date { get; set; }

        [Name("time")]
        public TimeSpan time { get; set; }
    }

    public sealed class Order_DtoMap : ClassMap<Order_Dto>
    {
        public Order_DtoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.order_id).Name("order_id");
            Map(m => m.date).Name("date");
            Map(m => m.time).Name("time");
        }
    }
}
