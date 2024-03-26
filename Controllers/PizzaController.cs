using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSalesAPI.Dto;
using PizzaPlaceSalesAPI.Services.CSVServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ICSVService _csvService;

        public PizzaController(ICSVService csvService)
        {
            _csvService = csvService;
        }

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
