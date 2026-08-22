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
        public IActionResult GetRooms()
        {
            var hotels = GetHotels();
            return Ok(hotels);
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
