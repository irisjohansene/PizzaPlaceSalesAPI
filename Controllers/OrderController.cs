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
    /// Controller for handling orders.
    /// </summary>
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICSVService _csvService;

        /// <summary>
        /// Constructor for OrderController.
        /// </summary>
        /// <param name="csvService">The CSV service instance.</param>
        public OrderController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        /// <summary>
        /// Endpoint for reading order CSV files.
        /// </summary>
        /// <param name="file">The uploaded CSV file containing order data.</param>
        /// <returns>Returns a list of orders from the uploaded CSV file.</returns>
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
