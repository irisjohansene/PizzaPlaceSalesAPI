using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSalesAPI.Dto;
using PizzaPlaceSalesAPI.Services.CSVServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypeController : ControllerBase
    {
        private readonly ICSVService _csvService;

        public PizzaTypeController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("read-pizzatype-csv")]
        public async Task<IActionResult> GetPizzaTypeCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                var pizzatypes = new List<Pizza_Type_Dto>();

                await foreach (var pizzatype in _csvService.ReadCSV<Pizza_Type_Dto>(file[0].OpenReadStream(), new Pizza_Type_DtoMap()))
                {
                    pizzatypes.Add(pizzatype);
                }
                return Ok(pizzatypes);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
