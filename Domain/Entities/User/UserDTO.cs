using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities;

public class UserDTO
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}
