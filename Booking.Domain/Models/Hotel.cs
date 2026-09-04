using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Models
{
    public class Hotel
    {
        public Hotel()
        {

        }
        public Hotel(string idname, int stars, string address)
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }

        public string City {  get; set; }

        public string Country { get; set; } = "Unknown";
        public string Rooms { get; set; }
        public string Description { get; set; }

    }
}
