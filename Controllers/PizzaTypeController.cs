using Microsoft.AspNetCore.Cors;
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
    /// Controller for handling pizza types.
    /// </summary>
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypeController : ControllerBase
    {
        private readonly ICSVService _csvService;

        /// <summary>
        /// Constructor for PizzaTypeController.
        /// </summary>
        /// <param name="csvService">The CSV service instance.</param>
        public PizzaTypeController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        /// <summary>
        /// Endpoint for reading pizza type CSV files.
        /// </summary>
        /// <param name="file">The uploaded CSV file containing pizza type data.</param>
        /// <returns>Returns a list of pizza types from the uploaded CSV file.</returns>
        [HttpPost("read-pizzatype-csv")]
        public async Task<IActionResult> GetPizzaTypeCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                var pizzaTypes = new List<Pizza_Type_Dto>();

                await foreach (var pizzaType in _csvService.ReadCSV<Pizza_Type_Dto>(file[0].OpenReadStream(), new Pizza_Type_DtoMap()))
                {
                    pizzaTypes.Add(pizzaType);
                }
                return Ok(pizzaTypes);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
