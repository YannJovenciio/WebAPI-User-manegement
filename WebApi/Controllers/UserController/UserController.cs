using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Application.interfaces.UseCases;
using WebApplication1.Controllers.Model;
using WebApplication1.Domain.Entities;

namespace WebApplication1.Controllers.UserController;

[ApiController]
[Route("[controller]")]
public class UserController(
    ILogger<UserController> logger,
    IGetAllUsersQueryHandler getCommand,
    IDeleteUserCommand deleteCommand,
    IAddUsersCommand addCommand,
    IUpdateUsersCommandHandler updateCommand
) : ControllerBase
{
    [HttpGet("GetUser")]
    public async Task<IActionResult> Get([FromQuery] int page)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("Request started: GET /api/Users");

        var users = await getCommand.HandleAsync(page);

        stopwatch.Stop();
        logger.LogInformation(
            "Request finished: GET /api/users in {ElapsedMilliseconds} ms",
            stopwatch.ElapsedMilliseconds
        );

        return Ok(new ApiResponse<IEnumerable<UserDTO>>(users));
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> Post(User user)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("Request started: Post /api/Users");

        await addCommand.AddUserAsync(user);

        stopwatch.Stop();
        logger.LogInformation(
            "Request finished: Post /api/users in {ElapsedMilliseconds} ms",
            stopwatch.ElapsedMilliseconds
        );

        return Ok(new ApiResponse<User>(user));
    }

    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> Delete(UserDTO user, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("Request start: Delete /api/Users");

        deleteCommand.DeleteUserAsync(user, cancellationToken);

        stopwatch.Stop();
        logger.LogInformation(
            "Request finished: Delete /api/Users in {ElapsedMilliseconds}",
            stopwatch.ElapsedMilliseconds
        );
        return NoContent();
    }

    [HttpPost("UpdateUser")]
    public async Task<UserDTO> Update(UserDTO userDTO)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("Request start: Post /api/Users");

        await updateCommand.handler(userDTO);
        stopwatch.Stop();
        logger.LogInformation(
            "Request finished: Post /api/Users in {ElapsedMilliseconds}",
            stopwatch.ElapsedMilliseconds
        );
        return userDTO;
    }
}
