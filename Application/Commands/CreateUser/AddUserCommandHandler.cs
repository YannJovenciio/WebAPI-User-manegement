using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.DbContex;

namespace WebApplication1.Application.Commands.CreateUser;

public class AddUserCommand(UserDbContext db) : IAddUsersCommand
{
    public async Task AddUserAsync(User entity)
    {
        await db.Users.AddAsync(entity);
    }
}
