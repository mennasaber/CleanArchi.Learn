using CleanArchi.Learn.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchi.Learn.Application.Features.User.Queries.GetUser
{
    public class GetUserQuery : IRequest<IdentityUser>
    {
        [Required(ErrorMessage =AppConstants.EMAIL_REQUIRED_MESSAGE)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage =AppConstants.PASSWORD_REQUIRED_MESSAGE)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
