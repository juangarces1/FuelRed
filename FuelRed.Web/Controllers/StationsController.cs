using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuelRed.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Controllers
{
    public class StationsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public StationsController(
            DataContext context,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
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

            StationEntity stationEntity = await _context.Stations
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
            StationViewModel model = new StationViewModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(StationViewModel stationViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if (stationViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(stationViewModel.LogoFile, "Stations");
                }

                StationEntity team = _converterHelper.ToStationEntity(stationViewModel, path, true);
                _context.Add(team);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already there is a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }

            return View(stationViewModel);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StationEntity stationEntity = await _context.Stations.FindAsync(id);
            if (stationEntity == null)
            {
                return NotFound();
            }
            StationViewModel stationViewModel = _converterHelper.ToStationViewModel(stationEntity);
            return View(stationViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StationViewModel stationViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = stationViewModel.LogoPath;

                if (stationViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(stationViewModel.LogoFile, "Stations");
                }

                StationEntity stationEntity = _converterHelper.ToStationEntity(stationViewModel, path, false);
                _context.Update(stationEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("updating"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists a Station {stationEntity.Name}. ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }
            return View(stationViewModel);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StationEntity stationEntity = await _context.Stations
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
