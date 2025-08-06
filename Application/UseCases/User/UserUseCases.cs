using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.UseCases;

public class UserUseCases : IUserUseCases
{
    public Task AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDTO>> GetAllUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateduserAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}
