using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities;

public class User
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public required string Password { get; set; }

    public User(string name,string email,string password)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }
}
