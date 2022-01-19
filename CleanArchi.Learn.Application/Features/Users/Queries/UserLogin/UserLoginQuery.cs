using CleanArchi.Learn.Domain;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Users.Queries.GetUser
{
    public class UserLoginQuery : IRequest<User>
    {
        [Required(ErrorMessage =AppConstants.EMAIL_REQUIRED_MESSAGE)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage =AppConstants.PASSWORD_REQUIRED_MESSAGE)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
