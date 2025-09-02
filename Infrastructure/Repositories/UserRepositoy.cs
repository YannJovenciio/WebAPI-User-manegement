using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.DbContex;

namespace WebApplication1.Domain.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var deleteUser = await _context
            .Users.Where(u => u.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        await _context.SaveChangesAsync();

        // A predicate is a function that returns a boolean value, typically used to test whether an element meets certain criteria.
        // In Entity Framework and LINQ, predicates are often used to filter data, for example: .Where(user => user.IsActive)
        // In your DeleteUserAsync method, you used a predicate in FirstOrDefaultAsync(x => x.id == id) to find the user by id.
        // You use predicates to specify which records to select, update, or delete based on a condition.
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
