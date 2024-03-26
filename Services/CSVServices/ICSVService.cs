

using CsvHelper.Configuration;

namespace PizzaPlaceSalesAPI.Services.CSVServices
{
    public interface ICSVService
    {
        IAsyncEnumerable<T> ReadCSV<T>(Stream file, ClassMap<T> classMap = null) where T : class;
    }
}