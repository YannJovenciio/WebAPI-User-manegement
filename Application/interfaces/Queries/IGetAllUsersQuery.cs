using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.interfaces.Queries;

public interface IGetAllUsersQuery
{
    public Task<IEnumerable<UserDTO>> ExecuteAsync();
}
