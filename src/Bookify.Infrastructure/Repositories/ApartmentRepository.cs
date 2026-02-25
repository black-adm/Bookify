using Bookify.Domain.Abstractions.Repositories;
using Bookify.Domain.Apartments;
using Bookify.Infrastructure.Persistence;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository(ApplicationDbContext dbContext)
    : Repository<Apartment>(dbContext), IApartmentRepository
{
}
