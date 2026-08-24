using Booking.Api.Services.Abstrations;
using System.Reflection.Metadata.Ecma335;

namespace Booking.Api.Services
{
    public class ScopedOperation : IScopedOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
