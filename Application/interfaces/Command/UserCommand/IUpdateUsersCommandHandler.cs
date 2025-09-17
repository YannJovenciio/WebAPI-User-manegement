using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.interfaces.Command;

public interface IUpdateUsersCommandHandler
{
    public Task UpdateUserCommand(UserDTO userDTO);
}
