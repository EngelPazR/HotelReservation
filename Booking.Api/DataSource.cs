using Booking.Domain.Models;

namespace Booking.Api
{
    public class DataSource
    {

        public DataSource()
        {
            Hotels = GetHotels();
        }

        public List<Hotel> Hotels { get; set; }

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
