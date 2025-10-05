using WebApplication1.Application.DTOs;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Repositories;

namespace WebApplication1.Application.Commands.DeleteUser;

public class DeleteUserCommand : IDeleteUserCommand
{
    private readonly IUserRepository _repository;

    public DeleteUserCommand(IUserRepository repository)
    {
        _repository = repository;
    }

    public void DeleteUserAsync(UserDTO user, CancellationToken cancellationToken)
    {
        _repository.DeleteUserAsync(user, cancellationToken);
    }
}
