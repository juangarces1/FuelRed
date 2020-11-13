using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelRed.Web.Controllers
{
    public class DownloadController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public DownloadController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task<IActionResult> Index()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            Download download = new Download
            {
                Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault(),
                Truck = _context.Trucks.Include(t => t.Tanks).FirstOrDefault(),             
                User = user,
                Date = DateTime.Now
            };
            return View(download);

          
        }
    }
}
