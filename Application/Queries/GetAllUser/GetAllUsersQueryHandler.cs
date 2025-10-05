using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.interfaces.UseCases;
using WebApplication1.Application.Queries;

namespace WebApplication1.Application.Queries.GetAllUser
{
    public class GetAllUsersQueryHandler(GetAllUsersQuery query) : IGetAllUsersQueryHandler
    {
        private readonly GetAllUsersQuery _query = query;

        public async Task<IEnumerable<UserDTO>> HandleAsync()
        {
            return await _query.ExecuteAsync();
        }

        public async Task<IEnumerable<UserDTO>> HandleAsync(int page)
        {
            return await _query.ExecuteAsync(page);
        }
    }
}
