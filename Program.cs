using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.Commands.CreateUser;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Application.interfaces.UseCases;
using WebApplication1.Application.Queries.GetAllUser;
using WebApplication1.Application.UseCases;
using WebApplication1.Domain.Repositories;
using WebApplication1.Infrastructure.DbContex;
using WebApplication1.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Dependency Injection - Hexagonal Architecture
builder.Services.AddSingleton<IWeatherForecastRepository, InMemoryWeatherForecastRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IGetAllUsersQueryHandler, GetAllUsersQueryHandler>();
builder.Services.AddSingleton<IAddUsersCommand, AddUserCommand>();

// Use Cases (Application Layer)
builder.Services.AddScoped<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>();

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite("Data Source=users.db"));
var app = builder.Build();

app.MapControllers();

app.Run();
