using FuelRed.Common.Enums;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using Microsoft.EntityFrameworkCore;
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
            await CheckStationAsync("Estacion San Gerardo", "301110568", "Grupo Poji S.A.", "100 mts sur CC.SS. Entrada Chomes Puntarenas");

            await CheckUserAsync("1010", "Juan", "Garces", "sebastian.garces23@gmail.com", "350 634 2747", "Calle Luna Calle Sol", "301110568", UserType.Admin);
            await CheckUserAsync("1010", "Pablo", "Cuesta", "me@gmail.com", "350 634 2747", "Calle Luna Calle Sol", "301110568", UserType.User);

            await CheckUsersAsync();
        }
        private async Task CheckUsersAsync()
        {
            for (int i = 1; i <= 30; i++)
            {
                await CheckUserAsync($"100{i}", "User", $"{i}", $"user{i}@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", "6546875", UserType.User);
            }
        }
        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string LegalCertificate,
            UserType userType)
        {
            UserEntity user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                StationEntity station = _context.Stations.FirstOrDefault(s => s.LegalCertificate == LegalCertificate);


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
                    Station = station,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task<StationEntity> CheckStationAsync(
           string Name,
           string LegalCertificate,
           string namelegal,
           string addrres)

        {
            StationEntity station = await _context.Stations.FirstOrDefaultAsync(s => s.LegalCertificate == LegalCertificate);
            if (station == null)
            {


                station = new StationEntity
                {
                    Name = Name,
                    LegalCertificate = LegalCertificate,
                    LegalName = namelegal,
                    Address = addrres,
                    LogoPath = "~/images/Stations/San Gerardo.png"

                };

                await _context.AddAsync(station);
                await _context.SaveChangesAsync();
            }

            return station;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _userHelper.CheckRoleAsync(UserType.StationAdmin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Pistero.ToString());
        }




    }

}
