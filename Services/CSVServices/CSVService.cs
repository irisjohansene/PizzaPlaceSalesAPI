using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace PizzaPlaceSalesAPI.Services.CSVServices
{
    /// <summary>
    /// Service for reading CSV files and mapping records to DTOs.
    /// </summary>
    public class CSVService : ICSVService
    {
        /// <inheritdoc/>
        public async IAsyncEnumerable<T> ReadCSV<T>(Stream file, ClassMap<T> classMap = null) where T : class
        {
            using (var reader = new StreamReader(file))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = header => header.Header.ToLower(),
                    HasHeaderRecord = true,
                    MissingFieldFound = null, // Ignore missing field errors
                    HeaderValidated = null // Ignore header validation errors
                };

                using (var csv = new CsvReader(reader, csvConfig))
                {
                    if (classMap != null)
                    {
                        csv.Context.RegisterClassMap(classMap); // Register provided class map
                    }

                    await csv.ReadAsync(); // Read header record
                    csv.ReadHeader();
                    while (await csv.ReadAsync()) // Read each CSV record asynchronously
                    {
                        yield return csv.GetRecord<T>(); // Yield each record
                    }
                }
            }
        }
    }
}
