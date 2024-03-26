using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PizzaPlaceSalesAPI.Services.CSVServices
{
    /// <summary>
    /// Service for reading CSV files and mapping records to DTOs.
    /// </summary>
    public interface ICSVService
    {
        /// <summary>
        /// Reads a CSV file asynchronously and maps each record to the specified DTO class.
        /// </summary>
        /// <typeparam name="T">The type of the DTO class.</typeparam>
        /// <param name="file">The stream of the CSV file.</param>
        /// <param name="classMap">Optional class map for custom mapping.</param>
        /// <returns>An asynchronous enumerable of DTO instances.</returns>
        IAsyncEnumerable<T> ReadCSV<T>(Stream file, ClassMap<T> classMap = null) where T : class;
    }
}
