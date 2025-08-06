using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.interfaces.Queries;
using WebApplication1.Infrastructure.DbContex;

namespace WebApplication1.Application.Queries;

public class GetAllUsersQuery(UserDbContext db) : IGetAllUsersQuery
{
    private readonly UserDbContext _db = db;

    public async Task<IEnumerable<UserDTO>> ExecuteAsync()
    {
        return await _db
            .Users.Select(x => new UserDTO { Email = x.Email, Name = x.Name })
            .ToListAsync();
    }
}
