using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.DTOs;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.UseCases;

public interface IUserUseCases
{
    public Task<UserDTO> GetUserAsync(Guid id);

    public Task AddUserAsync(User user);

    public Task DeleteUserAsync(Guid id);

    public Task UpdateduserAsync(UserDTO userDTO);

    public Task<List<UserDTO>> GetAllUserAsync();
}
