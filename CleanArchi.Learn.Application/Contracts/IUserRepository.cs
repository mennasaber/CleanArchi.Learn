using CleanArchi.Learn.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Contracts
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<IdentityResult> SignUpAsync(User user,string password);
        Task<User> LoginAsync(string email, string password);
    }
}
