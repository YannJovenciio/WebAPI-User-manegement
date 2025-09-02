using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.Commands.CreateUser;
using WebApplication1.Application.Commands.DeleteUser;
using WebApplication1.Application.interfaces.Command;
using WebApplication1.Application.interfaces.Queries;
using WebApplication1.Application.interfaces.UseCases;
using WebApplication1.Application.Queries;
using WebApplication1.Application.Queries.GetAllUser;
using WebApplication1.Application.UseCases;
using WebApplication1.Domain.Repositories;
using WebApplication1.Infrastructure.DbContex;
using WebApplication1.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173") // Seu frontend
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // ← ADICIONE ESTA LINHA
        }
    );

    // ✅ Política mais permissiva para desenvolvimento
    options.AddPolicy(
        "AllowAll", // Para desenvolvimento apenas!
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

// Authentication
// Dependency Injection - Hexagonal Architecture
// Repositories (Infrastructure Layer)
builder.Services.AddSingleton<IWeatherForecastRepository, InMemoryWeatherForecastRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Use Cases (Application Layer)
builder.Services.AddScoped<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>();
builder.Services.AddScoped<IGetAllUsersQueryHandler, GetAllUsersQueryHandler>();
builder.Services.AddScoped<IAddUsersCommand, AddUserCommand>();
builder.Services.AddScoped<GetAllUsersQuery>(); // ← Registrar sem interface
builder.Services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();

// Database
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite("Data Source=users.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
