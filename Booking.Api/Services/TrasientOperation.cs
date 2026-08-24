using Booking.Api.Services.Abstrations;

namespace Booking.Api.Services
{
    public class TrasientOperation : ITrasientOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

    }
}
