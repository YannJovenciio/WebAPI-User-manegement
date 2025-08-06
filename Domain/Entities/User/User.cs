using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
    }

    // Construtor sem parâmetros para o Entity Framework
    public User()
    {
        Id = Guid.NewGuid();
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }
}
