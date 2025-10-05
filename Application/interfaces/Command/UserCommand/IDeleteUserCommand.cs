using WebApplication1.Application.DTOs;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.interfaces.Command;

public interface IDeleteUserCommand
{
    public void DeleteUserAsync(UserDTO user, CancellationToken cancellationToken);
}
