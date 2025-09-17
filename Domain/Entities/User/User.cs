using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities.UserDepartament;

namespace WebApplication1.Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Departament Departament { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User(
        string name,
        string email,
        string password,
        Departament departament,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Departament = departament;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User()
    {
        Id = Guid.NewGuid();
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        Departament = Departament.Junior;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
