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
    /// Controller for handling order details.
    /// </summary>
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly ICSVService _csvService;

        /// <summary>
        /// Constructor for OrderDetailController.
        /// </summary>
        /// <param name="csvService">The CSV service instance.</param>
        public OrderDetailController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        /// <summary>
        /// Endpoint for reading order detail CSV files.
        /// </summary>
        /// <param name="file">The uploaded CSV file containing order detail data.</param>
        /// <returns>Returns a list of order details from the uploaded CSV file.</returns>
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
