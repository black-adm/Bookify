namespace Bookify.Application.Abstractions.Persistence.Queries;

internal sealed class ApartmentSqlQueries
{
    public const string SearchApartments = """
        SELECT
            a.id AS Id,
            a.name AS Name,
            a.description AS Description,
            a.price_amount AS Price,
            a.price_currency AS Currency,
            a.address_country AS Country,
            a.address_state AS State,
            a.address_zip_code AS ZipCode,
            a.address_city AS City,
            a.address_street AS Street
        FROM apartments
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM bookings AS b
            WHERE
                b.apartment_id = a.id
                b.duration_start <= @EndDate
                b.duration_end >= @StartDate
                b.status ANY(@ActiveBookingStatuses)
        )
        """;
}
