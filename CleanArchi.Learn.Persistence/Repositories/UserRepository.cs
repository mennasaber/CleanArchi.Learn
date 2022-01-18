using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public Task<IdentityUser> AddAsync(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AddAsync(IdentityUser entity, string password)
        {
            var result = await _userManager.CreateAsync(entity, password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(AppConstants.USER_ROLE))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppConstants.USER_ROLE));
                }
                await _userManager.AddToRoleAsync(entity, AppConstants.USER_ROLE);
                await _signInManager.SignInAsync(entity, isPersistent: false);
            }
            return result;
        }

        public Task DeleteAsync(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var isValid = await _userManager.CheckPasswordAsync(user, password);
                if (isValid)
                {
                    await _signInManager.PasswordSignInAsync(user,password,false,user.LockoutEnabled);
                    return user;
                }
            }
            return null;
        }

        public Task UpdateAsync(IdentityUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
