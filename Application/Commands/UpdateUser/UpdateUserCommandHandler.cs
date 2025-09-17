using WebApplication1.Application.DTOs;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Domain.Repositories;

namespace ebApplication1.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IUpdateUsersCommandHandler
{
    private readonly UserRepository _repository;

    public UpdateUserCommandHandler(UserRepository userRepository)
    {
        _repository = userRepository;
    }

    public Task handler(UserDTO userDTO)
    {
        return _repository.UpdateUserAsync(userDTO);
    }
}
