using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Abstractions.Persistence;
using Bookify.Application.Abstractions.Persistence.Queries;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<GetBookingQuery, BookingResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = BookingSqlQueries.GetBookingById;

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new { request.BookingId });

        return booking;
    }
}
