using Booking.Api.Services.Abstrations;

namespace Booking.Api.Services
{
    public class SingleonOperation : ISingleOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

    }
}
