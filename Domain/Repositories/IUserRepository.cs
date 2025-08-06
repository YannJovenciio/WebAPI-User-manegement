using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();

    public Task AddUserAsync(User user);
}
