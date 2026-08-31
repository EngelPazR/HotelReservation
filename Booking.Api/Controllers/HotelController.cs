using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using Booking.Domain.Models;
using System.Security.Cryptography.X509Certificates;


namespace Booking.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class HotelController : Controller
    {
    
        private readonly ILogger<HotelController> _logger;
        public HotelController(ILogger<HotelController> logger)
        {
       
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
      
        public IActionResult GetHotelByID(int id)
        {
           
            return Ok();
                     
        }

        [HttpPost]

        public IActionResult CreateHotel([FromBody] Hotel hotel)

        {
            return Ok(0);
        }

        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel update, int id)
        {
          
            return NoContent();

                  
        }

        [HttpDelete]
        public IActionResult DeleteHotel(int id)
        {
           
            return NoContent();
        }
       
    }
}
