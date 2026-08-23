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
        private readonly DataSource _datasource;
        public HotelController(DataSource dataSource)
        {
            _datasource = dataSource;
        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _datasource.Hotels;
            return Ok(hotels);
        }
        [HttpGet]
        [Route("{id}")]
      
        public IActionResult GetHotelByID(int id)
        {
            var hotels = _datasource.Hotels;
            var hotel = hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
                     
        }

        [HttpPost]

        public IActionResult CreateHotel([FromBody] Hotel hotel)

        {
            var hotels = _datasource.Hotels;
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelByID), new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel update, int id)
        {
            var hotels = _datasource.Hotels;
            var old = hotels.FirstOrDefault(h => h.Id == id);
            hotels.Remove(old);
            hotels.Add(update);

            if (old == null)
                return NotFound("No se encontraton Hoteles");

            return NoContent();

          

            
        }

        [HttpDelete]
        public IActionResult DeleteHotel(int id)
        {
            var hotels = _datasource.Hotels;
            var toDelete = hotels.FirstOrDefault(h => h.Id == id);
            hotels.Remove(toDelete);
            return NoContent();
        }
       
    }
}
