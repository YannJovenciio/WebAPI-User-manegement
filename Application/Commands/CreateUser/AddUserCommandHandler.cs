using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Repositories;

namespace WebApplication1.Application.Commands.CreateUser;

public class AddUserCommand : IAddUsersCommand
{
    private readonly IUserRepository _userRepository;

    public AddUserCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUserAsync(User entity)
    {
        await _userRepository.CreateUserAsync(entity);
    }
}
