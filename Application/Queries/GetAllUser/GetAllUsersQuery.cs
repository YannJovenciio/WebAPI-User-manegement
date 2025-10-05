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
            .OrderBy(name => name.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserDTO>> ExecuteAsync(int Page)
    {
        var PageLimit = 10;
        return await _db
            .Users.OrderBy(u => u.Name)
            .Select(x => new UserDTO { Email = x.Email, Name = x.Name })
            .OrderBy(u => u.Name)
            .Skip((Page - 1) * PageLimit)
            .Take(PageLimit)
            .ToListAsync();
    }
}
