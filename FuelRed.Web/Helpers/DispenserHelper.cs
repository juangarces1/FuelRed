using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Helpers
{
    public class DispenserHelper : IDispenserHelper
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public DispenserHelper(
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserEntity> signInManager,
            DataContext context,
            IUserHelper userHelper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _userHelper = userHelper;
        }

        public async Task<IQueryable<DispenserEntity>> GetDispensersAsync(string email)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                return null;
            }
            return  _context.Dispensers
                .Include(d=>d.Hoses)
              ;
             
        }


    }
}
