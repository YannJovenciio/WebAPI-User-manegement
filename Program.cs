using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.UseCases;
using WebApplication1.Domain.Repositories;
using WebApplication1.Infrastructure.DbContex;
using WebApplication1.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Authentication
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

// Dependency Injection - Hexagonal Architecture
// Repositories (Infrastructure Layer)
builder.Services.AddSingleton<IWeatherForecastRepository, InMemoryWeatherForecastRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

// Use Cases (Application Layer)
builder.Services.AddScoped<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>();

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite("Data Source=users.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
