using CleanArchi.Learn.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Users.Commands.AddUser
{
    public class UserSignUpCommand : IRequest<IdentityResult>
    {
        [Required(ErrorMessage = AppConstants.USERNAME_REQUIRED_MESSAGE)]
        public string Username { get; set; }
        [Required(ErrorMessage = AppConstants.EMAIL_REQUIRED_MESSAGE)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = AppConstants.PASSWORD_REQUIRED_MESSAGE)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = AppConstants.PASSWORD_CONFIRMATION_MESSAGE)]
        public string ConfirmPassword { get; set; }
    }
}
