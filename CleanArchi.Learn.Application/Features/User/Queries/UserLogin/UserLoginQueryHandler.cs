using CleanArchi.Learn.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.User.Queries.GetUser
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, IdentityUser>
    {
        private readonly IUserRepository _userRepository;

        public UserLoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityUser> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.LoginAsync(request.Email, request.Password);
            return user;
        }
    }
}
