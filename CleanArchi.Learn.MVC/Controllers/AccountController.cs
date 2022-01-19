using CleanArchi.Learn.Application.Features.Users.Commands.AddUser;
using CleanArchi.Learn.Application.Features.Users.Queries.GetUser;
using CleanArchi.Learn.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchi.Learn.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginQuery getUserQuery)
        {
            var user = await _mediator.Send(getUserQuery);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.TryAddModelError("Login", AppConstants.INVALID_LOGIN);
            return View(getUserQuery);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpCommand userSignUpCommand)
        {
            try
            {
                var result = await _mediator.Send(userSignUpCommand);
                if (result == null)
                {
                    ModelState.AddModelError("Username", "This username is token");
                    return View(userSignUpCommand);
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(userSignUpCommand);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public IActionResult AccessDenied()
        {
            return Content(AppConstants.ACCESS_DENIED);
        }
    }
}
