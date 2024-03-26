using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSalesAPI.Dto;
using PizzaPlaceSalesAPI.Services.CSVServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICSVService _csvService;

        public OrderController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("read-order-csv")]
        public async Task<IActionResult> GetOrderCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                var orders = new List<Order_Dto>();

                await foreach (var order in _csvService.ReadCSV<Order_Dto>(file[0].OpenReadStream(), new Order_DtoMap()))
                {
                    orders.Add(order);
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
