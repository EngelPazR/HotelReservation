using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using Booking.Domain.Models;
using System.Security.Cryptography.X509Certificates;
using Booking.Api.Services;
using Booking.Api.Services.Abstrations;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class HotelController : Controller
    {
        private readonly MyFirstService _myFirstService;
        private readonly ISingleOperation _singleton;
        private readonly ITrasientOperation _trasient;
        private readonly IScopedOperation _scoped;
        private readonly ILogger<HotelController> _logger;
        public HotelController(MyFirstService service, ITrasientOperation trasient, IScopedOperation scoped, ISingleOperation singleton, ILogger<HotelController> logger)
        {
            _myFirstService = service;
            _trasient = trasient;
            _scoped = scoped;
            _singleton = singleton;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            _logger.LogInformation($"GUID of singleton: {_singleton.Guid}");
            _logger.LogInformation($"GUID of Trasient: {_trasient.Guid}");
            _logger.LogInformation($"GUID of Scoped: {_scoped.Guid}");

            var hotels = _myFirstService.GetHotels();
            return Ok(hotels);
        }
        [HttpGet]
        [Route("{id}")]
      
        public IActionResult GetHotelByID(int id)
        {
            var hotels = _myFirstService.GetHotels();
            var hotel = hotels.FirstOrDefault(h => h.Id == id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
                     
        }

        [HttpPost]

        public IActionResult CreateHotel([FromBody] Hotel hotel)

        {
            var hotels = _myFirstService.GetHotels();
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelByID), new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel update, int id)
        {
            var hotels = _myFirstService.GetHotels();
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
            var hotels = _myFirstService.GetHotels();
            var toDelete = hotels.FirstOrDefault(h => h.Id == id);
            hotels.Remove(toDelete);
            return NoContent();
        }
       
    }
}
