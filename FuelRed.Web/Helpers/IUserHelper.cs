using Microsoft.AspNetCore.Identity;
using FuelRed.Web.Data.Entities;
using System.Threading.Tasks;
using FuelRed.Web.Models;
using FuelRed.Common.Enums;
using System;
using System.Collections.Generic;

namespace FuelRed.Web.Helpers
{
    public interface IUserHelper
    {

        Task<IdentityResult> AddRole(UserEntity user, string role);

        Task<IdentityResult> DeleteRole(UserEntity user, string role);

        Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(UserEntity user);


        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<List<UserEntity>> GetAllUsersByStationAsync(string email);

        Task<UserEntity> AddUserAsync(AddUserViewModel model, string path, UserType userType);
        Task<UserEntity> GetUserAsync(string email);

        Task<List<UserEntity>> GetAllUsersAsync();

        Task<UserEntity> GetUserAsync(Guid userId);

        Task<UserEntity> GetUserByIdAsync(string userId);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task RemoveUserFromRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);


    }
}

