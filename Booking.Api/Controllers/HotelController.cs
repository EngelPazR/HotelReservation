using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using Booking.Domain.Models;
using System.Security.Cryptography.X509Certificates;
using CwBooking.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Booking.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class HotelController : Controller
    {
    
        private readonly ILogger<HotelController> _logger;
        private readonly HttpContext _http;
        private readonly DataContext _ctx;
        public HotelController(ILogger<HotelController> logger, IHttpContextAccessor httpContextAccessor, DataContext ctx)
        {
       
            _logger = logger;
            _http = httpContextAccessor.HttpContext;
            _ctx = ctx;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _ctx.Hotels.ToListAsync();
            return Ok(hotels);
        }
        
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHotelByID(int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.Id == id);  
           
            return Ok(hotel);
                     
        }

        [HttpPost]

        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)

        {
            _ctx.Hotels.Add(hotel);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHotelByID), new {id = hotel.Id}, hotel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel update, int id)
        {
            var hotels = await _ctx.Hotels.FirstOrDefaultAsync(h =>h.Id == id);
            hotels.Stars = update.Stars;
hotels.Description = update.Description;
            hotels.Name = update.Name;

            _ctx.Hotels.Update(hotels);
            await _ctx.SaveChangesAsync();

            return NoContent();

                  
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotel(int id)
        {
           var hotels  = await _ctx.Hotels.FirstAsync(h => h.Id == id);
            _ctx.Hotels.Remove(hotels);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
       
    }
}
