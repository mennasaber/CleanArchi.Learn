using AutoMapper;
using CleanArchi.Learn.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, IdentityResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityUser>(request);
            var result = await _userRepository.AddAsync(user, request.Password);
            return result;
        }
    }
}
