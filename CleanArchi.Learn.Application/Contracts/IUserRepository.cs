using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Contracts
{
    public interface IUserRepository : IAsyncRepository<IdentityUser>
    {
        Task<IdentityResult> AddAsync(IdentityUser entity,string password);
        Task<IdentityUser> LoginAsync(string email, string password);
    }
}
