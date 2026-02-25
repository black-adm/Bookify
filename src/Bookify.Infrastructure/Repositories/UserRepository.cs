using Bookify.Domain.Abstractions.Repositories;
using Bookify.Domain.Users;
using Bookify.Infrastructure.Persistence;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext dbContext)
    : Repository<User>(dbContext), IUserRepository
{
}
