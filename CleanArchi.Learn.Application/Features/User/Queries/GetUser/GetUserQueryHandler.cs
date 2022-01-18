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
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IdentityUser>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.LoginAsync(request.Email, request.Password);
            return user;
        }
    }
}
