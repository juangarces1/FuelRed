using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;

namespace FuelRed.Web.Controllers
{
    public class SeraphinsController : Controller
    {
        private readonly DataContext _context;

        public SeraphinsController(DataContext context)
        {
            _context = context;
        }

        // GET: Seraphins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seraphin.ToListAsync());
        }

        // GET: Seraphins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seraphin = await _context.Seraphin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seraphin == null)
            {
                return NotFound();
            }

            return View(seraphin);
        }

        // GET: Seraphins/Create
        public IActionResult Create(int id)
        {
            Seraphin seraphin = new Seraphin();

            seraphin.IdStation = id;
           
            return View(seraphin);
        }

        // POST: Seraphins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seraphin seraphin)
        {
            if (ModelState.IsValid)
            {
                seraphin.Station = _context.Stations.Find(seraphin.IdStation);
                seraphin.Id = 0;
                _context.Add(seraphin);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seraphin);
        }

        // GET: Seraphins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seraphin = await _context.Seraphin.FindAsync(id);
            if (seraphin == null)
            {
                return NotFound();
            }
            return View(seraphin);
        }

        // POST: Seraphins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seraphin seraphin)
        {
            if (id != seraphin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seraphin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeraphinExists(seraphin.Id))
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
            return View(seraphin);
        }

        // GET: Seraphins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seraphin = await _context.Seraphin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seraphin == null)
            {
                return NotFound();
            }

            return View(seraphin);
        }

        // POST: Seraphins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seraphin = await _context.Seraphin.FindAsync(id);
            _context.Seraphin.Remove(seraphin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeraphinExists(int id)
        {
            return _context.Seraphin.Any(e => e.Id == id);
        }
    }
}
