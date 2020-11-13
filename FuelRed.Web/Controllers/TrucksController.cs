using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;

namespace FuelRed.Web.Controllers
{
    public class TrucksController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public TrucksController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            UserEntity usera = await  _userHelper.GetUserAsync(User.Identity.Name);
            return View(await _context.Trucks
                .Include(t => t.Station)
                .Include(t=>t.Tanks)
                .ThenInclude(t=>t.Compartments)
                .Where(t => t.Station == usera.Station).ToListAsync());
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks.Include(t=>t.Tanks)
                .ThenInclude(t=>t.Compartments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }
            
            return View(truck);
        }

        public async Task<IActionResult> DetailsTank(int id)
        {
           

            var tank = await _context.TruckTanks.Include(t => t.Compartments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tank == null)
            {
                return NotFound();
            }
            var truck = await _context.Trucks.Include(t => t.Tanks)
                .Where(t => t.Tanks.Contains(tank)).FirstOrDefaultAsync();
            tank.IdTruck = truck.Id;
            return View(tank);
        }

      

        public IActionResult CreateTruckTank(int id)
        {
           
            
            TruckTank tank = new TruckTank
            {
                IdTruck = id
            };
            return View(tank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTruckTank(TruckTank tank)
        {
            if (ModelState.IsValid)
            {
                int var = tank.IdTruck;
                tank.Truck = _context.Trucks.Find(tank.IdTruck);
                tank.Id = 0;
                    
                _context.Add(tank);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{var}");
            }
            return View(tank);
        }

        public IActionResult AddCompartment(int id)
        {


            Compartment comp = new Compartment
            {
                IdTank = id
            };
            return View(comp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCompartment(Compartment comp)
        {
            if (ModelState.IsValid)
            {
                int var = comp.IdTank;
                comp.Tank = _context.TruckTanks.Find(var);
                comp.Id = 0;

                _context.Add(comp);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(DetailsTank)}/{var}");
            }
            return View(comp);
        }


        public async Task<IActionResult> Create()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            Truck truck = new Truck
            {
                IdStation = user.Station.Id
            };
            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Truck truck)
        {
            if (ModelState.IsValid)
            {
                truck.Station = _context.Stations.Find(truck.IdStation);
                _context.Add(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks.Include(t=>t.Station).FirstOrDefaultAsync(t => t.Id==id);
            
            if (truck == null)
            {
                return NotFound();
            }
            truck.IdStation = truck.Station.Id;
            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Truck truck)
        {
            if (id != truck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    truck.Station = _context.Stations.Find(id);
                    _context.Update(truck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truck.Id))
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
            return View(truck);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .Include(t=>t.Tanks)
                .ThenInclude(t=>t.Compartments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }            
            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> DeleteCompartment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comp = await _context.Compartments
               .FirstOrDefaultAsync(m => m.Id == id);
            if (comp == null)
            {
                return NotFound();
            }
            var tank = _context.TruckTanks
                .Include(t => t.Compartments)
                .Where(t => t.Compartments
                .Contains(comp))
                .FirstOrDefault();
            _context.Compartments.Remove(comp);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsTank)}/{tank.Id}");
        }
        public async Task<IActionResult> DeleteTank(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.TruckTanks
                .Include(t => t.Truck)
                .Include(t => t.Compartments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tank == null)
            {
                return NotFound();
            }
            int var = tank.Truck.Id;
            _context.TruckTanks.Remove(tank);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{var}");
        }


        private bool TruckExists(int id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
