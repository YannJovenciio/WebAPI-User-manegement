using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Application.interfaces.Queries;
using WebApplication1.Application.interfaces.UseCases;
using WebApplication1.Controllers.Model;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Repositories;

namespace WebApplication1.Controllers.UserController;

public class UserController(
    ILogger<UserController> logger,
    IGetAllUsersQueryHandler handler,
    IAddUsersCommand usersCommand
) : ControllerBase
{
    [HttpGet(Name = "ReturnUsers")]
    public async Task<IActionResult> Get()
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("Request started: GET /api/Users");

        var users = await handler.HandleAsync();

        stopwatch.Stop();
        logger.LogInformation(
            "Request finished: GET /api/users in {ElapsedMilliseconds} ms",
            stopwatch.ElapsedMilliseconds
        );

        return Ok(new ApiResponse<IEnumerable<UserDTO>>(users));
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("Request started: Post /api/Users");

        await usersCommand.AddUserAsync(user);

        stopwatch.Stop();
        logger.LogInformation(
            "Request finished: Post /api/users in {ElapsedMilliseconds} ms",
            stopwatch.ElapsedMilliseconds
        );

        return Ok(new ApiResponse<User>(user));
    }
}
