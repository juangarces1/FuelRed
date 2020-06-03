using FuelRed.Common.Enums;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
          
            await CheckUserAsync("1010", "Juan", "Garces", "sebastian.garces23@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            //await CheckUsersAsync();    
        }
        private async Task CheckUsersAsync()
        {
            for (int i = 1; i <= 30; i++)
            {
                await CheckUserAsync($"100{i}", "User", $"{i}", $"user{i}@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            }
        }
        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,          
            UserType userType)
                {
                    var user = await _userHelper.GetUserAsync(email);
                    if (user == null)
                    {
                var station = _context.Stations.Find(1);
                        
                user = new UserEntity
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            UserName = email,
                            PhoneNumber = phone,
                            Address = address,
                            Document = document,                   
                            UserType = userType,
                            Station= user.Station,
                        };

                        await _userHelper.AddUserAsync(user, "123456");
                        await _userHelper.AddUserToRoleAsync(user, userType.ToString());
                    }

                    return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

     


    }

}
