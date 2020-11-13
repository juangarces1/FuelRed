using Microsoft.AspNetCore.Identity;
using FuelRed.Web.Data.Entities;
using System.Threading.Tasks;
using FuelRed.Web.Models;
using FuelRed.Common.Enums;
using FuelRed.Web.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FuelRed.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly DataContext _context;

        public UserHelper(
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserEntity> signInManager,
            DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IdentityResult> AddRole(UserEntity user, string role)
        {
           return  await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> DeleteRole(UserEntity user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserAsync(UserEntity user)
        {
            return await _userManager.UpdateAsync(user);
        }


        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<UserEntity> AddUserAsync(AddUserViewModel model, string path, UserType userType)
        {
            UserEntity userEntity = new UserEntity
            {
                Address = model.Address,
                Document = model.Document,
                Email = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Station = await _context.Stations.FindAsync(model.StationId),
                PicturePath = path,
                PhoneNumber = model.PhoneNumber,              
                UserName = model.Username,
                UserType = userType
            };

            IdentityResult result = await _userManager.CreateAsync(userEntity, model.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            UserEntity newUser = await GetUserAsync(model.Username);
            await AddUserToRoleAsync(newUser, userEntity.UserType.ToString());
            return newUser;
        }

        public async Task<IdentityResult> AddUserAsync(UserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserEntity user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveUserFromRoleAsync(UserEntity user, string roleName)
        {
            await _userManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<UserEntity> GetUserAsync(Guid userId)
        {
            return await _context.Users
                .Include(s => s.Station)
                .FirstOrDefaultAsync(u => u.Id == userId.ToString());
        }

        public async Task<UserEntity> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(s => s.Station)
                .FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task<bool> IsUserInRoleAsync(UserEntity user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<List<UserEntity>> GetAllUsersByStationAsync(string email)
        {
            var user = await GetUserAsync(email);

            return await _userManager.Users
                .Include(u => u.Station)
                .Where(u=>u.Station==user.Station)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {           

            return await _userManager.Users
                .Include(u => u.Station)                
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
