using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain;
using CleanArchi.Learn.Domain.Entities;
using CleanArchi.Learn.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> SignUpAsync(User user, string password)
        {
            //Always return null
            var nameIsExist = await _userManager.FindByNameAsync(user.UserName.ToUpper().Normalize());
            if (nameIsExist != null) return null;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(AppConstants.USER_ROLE))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppConstants.USER_ROLE));
                }
                await _userManager.AddToRoleAsync(user, AppConstants.USER_ROLE);
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }
        private void SaveUserId(string userId)
        {
            if (SessionHelper.GetObjectFromJson<string>(_httpContextAccessor.HttpContext.Session, AppConstants.USER) == null)
            {
                SessionHelper.SetObjectAsJson(_httpContextAccessor.HttpContext.Session, AppConstants.USER, userId);
            }
        }
        private string GetUserId()
        {
            //return SessionHelper.GetObjectFromJson<string>(_httpContextAccessor.HttpContext.Session, "user");
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetCurrentUser()
        {
            var user = await _userManager.FindByIdAsync(GetUserId());
            return user;
        }
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var isValid = await _userManager.CheckPasswordAsync(user, password);
                if (isValid)
                {
                    await _signInManager.PasswordSignInAsync(user, password, false, user.LockoutEnabled);
                    return user;
                }
            }
            return null;
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
