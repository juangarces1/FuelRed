using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;

        public StationsController(
            DataContext context,
            IImageHelper imageHelper,
            IConverterHelper converterHelper,
            IUserHelper userHelper,
            ICombosHelper combosHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
        }

        // GET: Stations
        public async Task<IActionResult> Index()
        {
            UserEntity user = await _userHelper.GetUserAsync(this.User.Identity.Name);
            return View(_context.Stations
                    .Include(c => c.Dispensers)
                    .ThenInclude(s => s.Hoses)
                    .Where(s => s.Id == user.Station.Id)
                    .ToList());
        }



        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StationEntity station = await _context.Stations.Include(s => s.Dispensers)
                .ThenInclude(d => d.Hoses)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        //public  IActionResult AddItemTemp()
        //{



        //    MeasurementItemTemp model = new MeasurementItemTemp
        //    {
        //        Dispensers = _combosHelper.GetComboDispensers(),
        //        Hoses = _combosHelper.GetComboHoses(0)
        //    };



        //    return View(model);
        //}

        //public async Task<IActionResult> Medidas()
        //{
        //    UserEntity user = await _userHelper.GetUserAsync(this.User.Identity.Name);
        //    MeasurementViewModel measurement = new MeasurementViewModel();
        //    measurement.Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault();
        //    measurement.User = user;
        //    measurement.Date = DateTime.Now;
        //    measurement.items = _context.MeasurementItemTemps.ToList();

        //    return View(measurement);
        //}

        public async Task<IActionResult> DetailsDispenser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispenserEntity dispenser = await _context.Dispensers.Include(s => s.Hoses)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (dispenser == null)
            {
                return NotFound();
            }

            return View(dispenser);
        }

        [HttpGet]
        public async Task<IActionResult> AddDispenser(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            StationEntity station = await _context.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            DispenserEntity model = new DispenserEntity { IdStation = station.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDispenser(DispenserEntity dispsenser)
        {
            if (ModelState.IsValid)
            {
                StationEntity station = await _context.Stations
                    .Include(c => c.Dispensers)
                    .FirstOrDefaultAsync(c => c.Id == dispsenser.IdStation);
                if (station == null)
                {
                    return NotFound();
                }

                try
                {
                    dispsenser.Id = 0;
                    station.Dispensers.Add(dispsenser);
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{station.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(dispsenser);
        }


        [HttpGet]
        public async Task<IActionResult> AddHose(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            DispenserEntity dispenser = await _context.Dispensers.FindAsync(id);
            if (dispenser == null)
            {
                return NotFound();
            }

            HoseEntity model = new HoseEntity { IdDispenser = dispenser.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHose(HoseEntity hose)
        {
            if (ModelState.IsValid)
            {
                DispenserEntity dispenser = await _context.Dispensers
                    .Include(c => c.Hoses)
                    .FirstOrDefaultAsync(c => c.Id == hose.IdDispenser);
                if (dispenser == null)
                {
                    return NotFound();
                }

                switch (hose.Type)
                {
                    case "1":
                        hose.Type = TypeFuel.Regular.ToString();
                        break;

                    case "0":
                        hose.Type = TypeFuel.Diesel.ToString();
                        break;

                    case "2":
                        hose.Type = TypeFuel.Super.ToString();
                        break;
                    case "3":
                        hose.Type = TypeFuel.Exonerado.ToString();
                        break;
                }

                try
                {
                    hose.Id = 0;
                    dispenser.Hoses.Add(hose);
                    _context.Update(dispenser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsDispenser)}/{dispenser.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(hose);
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

        public async Task<IActionResult> DeleteDispenser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispenserEntity dispenser = await _context.Dispensers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dispenser == null)
            {
                return NotFound();
            }

            _context.Dispensers.Remove(dispenser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteHose(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HoseEntity hose = await _context.Hoses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hose == null)
            {
                return NotFound();
            }

            _context.Hoses.Remove(hose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //public ActionResult DispenserFind()
        //{

        //    return View("AddItemTemp");
        //}


        private bool StationEntityExists(int id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }

        //public JsonResult GetHoses(int dispenserId)
        //{

        //    DispenserEntity dispenser = _context.Dispensers
        //         .Include(d => d.Hoses)
        //         .FirstOrDefault(d => d.Id == dispenserId);
        //    if (dispenser == null)
        //    {
        //        return null;
        //    }

        //    return Json(dispenser.Hoses.OrderBy(h=>h.Type));
        //}
    }
}
