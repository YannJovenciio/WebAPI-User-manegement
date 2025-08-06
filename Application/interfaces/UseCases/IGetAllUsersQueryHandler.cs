using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.interfaces.UseCases;

public interface IGetAllUsersQueryHandler
{
    Task<IEnumerable<UserDTO>> HandleAsync();
}
