using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.DTOs;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateUserAsync(User user);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken);
    Task<UserDTO> UpdateUserAsync(UserDTO userDTO);
}
