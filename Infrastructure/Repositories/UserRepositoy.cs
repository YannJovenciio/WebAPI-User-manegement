using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.DTOs;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.DbContex;

namespace WebApplication1.Domain.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    private readonly ILogger<UserRepository> _logger;

    public UserRepository(UserDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var emailExists = await _context.Users.AnyAsync(u =>
            u.Email == user.Email && u.Name == user.Name
        );
        if (!emailExists)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        _logger.LogInformation($"User with id {user.Id} already exists");
        return user;
    }

    public async Task DeleteUserAsync(UserDTO userDTO, CancellationToken cancellationToken)
    {
        await _context
            .Users.Where(u => u.Name == userDTO.Name && u.Email == userDTO.Email)
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

    public async Task<UserDTO> UpdateUserAsync(UserDTO userDTO)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDTO.id);

        if (user == null)
            return null;

        user.Name = userDTO.Name;
        user.Email = userDTO.Email;
        user.Password = userDTO.Password;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return userDTO;
    }
}
