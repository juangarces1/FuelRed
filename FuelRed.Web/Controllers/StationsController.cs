using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelRed.Web.Data.Entities;
using Soccer.Web.Data;

namespace FuelRed.Web.Controllers
{
    public class StationsController : Controller
    {
        private readonly DataContext _context;

        public StationsController(DataContext context)
        {
            _context = context;
        }

        // GET: Stations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stations.ToListAsync());
        }

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationEntity = await _context.Stations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stationEntity == null)
            {
                return NotFound();
            }

            return View(stationEntity);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StationEntity stationEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stationEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists the Station:{stationEntity.Name}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(stationEntity);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationEntity = await _context.Stations.FindAsync(id);
            if (stationEntity == null)
            {
                return NotFound();
            }
            return View(stationEntity);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,LegalCertificate,LogoPath")] StationEntity stationEntity)
        {
            if (id != stationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationEntityExists(stationEntity.Id))
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
            return View(stationEntity);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationEntity = await _context.Stations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stationEntity == null)
            {
                return NotFound();
            }

            _context.Stations.Remove(stationEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool StationEntityExists(int id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }
    }
}
