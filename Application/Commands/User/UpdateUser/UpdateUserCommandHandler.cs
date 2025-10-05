using WebApplication1.Application.DTOs;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Domain.Repositories;

namespace ebApplication1.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IUpdateUsersCommandHandler
{
    private readonly IUserRepository _repository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    public Task handler(UserDTO userDTO)
    {
        return _repository.UpdateUserAsync(userDTO);
    }
}
