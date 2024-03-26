using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaPlaceSalesAPI.Dto;
using PizzaPlaceSalesAPI.Services.CSVServices;

namespace PizzaPlaceSalesAPI.Controllers
{
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly ICSVService _csvService;

        public OrderDetailController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("read-orderdetail-csv")]
        public async Task<IActionResult> GetOrderDetailCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                var orderdetails = new List<Order_Detail_Dto>();

                await foreach (var order_detail in _csvService.ReadCSV<Order_Detail_Dto>(file[0].OpenReadStream(), new Order_Detail_DtoMap()))
                {
                    orderdetails.Add(order_detail);
                }
                return Ok(orderdetails);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
