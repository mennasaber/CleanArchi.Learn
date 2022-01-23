using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Users.Queries.GetUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetCurrentUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetCurrentUser();
        }
    }
}
