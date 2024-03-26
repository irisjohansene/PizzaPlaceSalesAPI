using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSalesAPI.Dto;
using PizzaPlaceSalesAPI.Services.CSVServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PizzaPlaceSalesAPI.Controllers
{
    /// <summary>
    /// Controller for handling pizza data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ICSVService _csvService;

        /// <summary>
        /// Constructor for PizzaController.
        /// </summary>
        /// <param name="csvService">The CSV service instance.</param>
        public PizzaController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        /// <summary>
        /// Endpoint for reading pizza CSV files.
        /// </summary>
        /// <param name="file">The uploaded CSV file containing pizza data.</param>
        /// <returns>Returns a list of pizzas from the uploaded CSV file.</returns>
        [HttpPost("read-pizza-csv")]
        public async Task<IActionResult> GetPizzaCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                var pizzas = new List<Pizza_Dto>();

                await foreach (var pizza in _csvService.ReadCSV<Pizza_Dto>(file[0].OpenReadStream(), new Pizza_DtoMap()))
                {
                    pizzas.Add(pizza);
                }
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
