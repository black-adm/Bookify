using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;

namespace Bookify.Domain.Abstractions.Repositories;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Booking booking);

    Task<bool> IsOverlappingAsync(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);
}
