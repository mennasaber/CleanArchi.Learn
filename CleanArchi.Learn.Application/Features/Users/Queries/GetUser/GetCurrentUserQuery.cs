using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Users.Queries.GetUser
{
    public class GetCurrentUserQuery : IRequest<User>
    {
    }
}
