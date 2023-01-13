using Karami.Domain.User.Contracts.Interfaces;
using Karami.Domain.User.Entities;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class UserCommandRepository : IUserCommandRepository
{
    private readonly SQLContext _context;

    public UserCommandRepository(SQLContext context) => _context = context;

    public void Add(User entity) => _context.Users.Add(entity);

    public void Change(User entity) => _context.Users.Update(entity);
}