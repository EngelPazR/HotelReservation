using Booking.Domain.Models;

namespace Booking.Api.Services
{
    public class MyFirstService
    {

        private readonly DataSource _dataSource;

        public MyFirstService(DataSource datasource)
        {
            _dataSource = datasource;
        }

        public List<Hotel> GetHotels(){
            return _dataSource.Hotels;
        }
    }

    
    } 
