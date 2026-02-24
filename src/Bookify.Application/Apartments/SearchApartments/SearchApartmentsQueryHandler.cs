using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Abstractions.Persistence;
using Bookify.Application.Abstractions.Persistence.Queries;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Dapper;

namespace Bookify.Application.Apartments.SearchApartments;

internal sealed class SearchApartmentsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    private static readonly int[] ActiveBookingStatuses =
    [
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    ];

    public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(
        SearchApartmentsQuery request,
        CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<ApartmentResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = ApartmentSqlQueries.SearchApartments;

        var apartments = await connection
            .QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                sql,
                (apartment, address) =>
                {
                    apartment.Address = address;
                    return apartment;
                },
                new
                {
                    request.StartDate,
                    request.EndDate,
                    ActiveBookingStatuses
                });

        return apartments.ToList();
    }
}
