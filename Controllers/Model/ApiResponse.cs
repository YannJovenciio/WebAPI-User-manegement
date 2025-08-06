using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.Model;

public class ApiResponse<TData>(TData data)
{
    public TData Data { get; private set; } = data;
}
