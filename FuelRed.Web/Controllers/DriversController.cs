using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Controllers
{
    public class DriversController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public DriversController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
           _userHelper = userHelper;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            //UserEntity user =  await _userHelper.GetUserAsync(User.Identity.Name);
            return View(await _context.Drivers.ToListAsync());
            //.Where(d => d.Station == user.Station)

        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public async Task<IActionResult> Create()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            Driver driver = new Driver
            {
                IdStation = user.Station.Id
            };
            return View(driver);
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Driver driver)
        {
            if (ModelState.IsValid)
            {
                driver.Station = await _context.Stations.FindAsync(driver.IdStation);
                driver.Id = 0;
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = await _context.Drivers.Include(d => d.Station).FirstOrDefaultAsync(d => d.Id == id);
            driver.IdStation = driver.Station.Id;
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,Name,LastName,PhoneNumber")] Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    driver.Station = await _context.Stations.FindAsync(driver.IdStation);
                    
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
