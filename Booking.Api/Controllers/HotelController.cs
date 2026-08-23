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

        public HotelController()
        {

        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = GetHotels();
            return Ok(hotels);
        }
        [HttpGet]
        [Route("{id}")]
      
        public IActionResult GetHotelByID(int id)
        {
            var hotels = GetHotels();
            var hotel = hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
                     
        }

        [HttpPost]

        public IActionResult CreateHotel([FromBody] Hotel hotel)

        {
            var hotels = GetHotels();
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelByID), new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel update, int id)
        {
            var hotels = GetHotels();
            var old = hotels.FirstOrDefault(h => h.Id == id);
            hotels.Remove(old);
            hotels.Add(update);
            return NoContent();

        }
        private List<Hotel> GetHotels()
        {
            return new List<Hotel>
            {
                             
                new Hotel {
                Id = 1,
                Name = "Holiday Inn",
                Stars = 5, 
                Country = "Nicaragua",
                City = "Managua"
                }, 

                new Hotel
                {
                    Id = 2, 
                    Name = "La perla",
                    Stars = 5,
                    Country = "Leon",
                    City = "Leon"
                }

            };
        }
    }
}
