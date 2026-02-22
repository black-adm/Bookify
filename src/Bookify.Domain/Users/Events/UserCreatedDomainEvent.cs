using Bookify.Domain.Abstractions.Interfaces;

namespace Bookify.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
