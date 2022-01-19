using AutoMapper;
using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Users.Commands.AddUser
{
    public class UserSignUpCommandHandler : IRequestHandler<UserSignUpCommand, IdentityResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserSignUpCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Handle(UserSignUpCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userRepository.SignUpAsync(user, request.Password);
            return result;
        }
    }
}
