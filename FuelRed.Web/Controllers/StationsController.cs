using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
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
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            return View(_context.Stations
                    .Include(c => c.Dispensers)
                    .ThenInclude(s => s.Hoses)
                    .Where(s => s.Id == user.Station.Id)
                    .ToList());
        }

        public async Task<IActionResult> IndexAdmin()
        {

            return View(await _context.Stations
                    .Include(c => c.Dispensers)
                    .ThenInclude(s => s.Hoses)
                    .ToListAsync());
        }

        public async Task<IActionResult> IndexMeaDisp()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            return View(_context.MeaDisps
                .Include(m => m.User)
                .Include(m => m.MeaItems)
                .ToList());

        }

        public async Task<IActionResult> DetailsMeaDisp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _context.MeaDisps
                    .Include(m => m.Station)
                    .Include(m => m.Seraphin)
                    .Include(m => m.User)
                    .Include(m => m.MeaItems)
                    .ThenInclude(m => m.Dispenser)
                    .Include(m => m.MeaItems)
                    .ThenInclude(m => m.Hose)
                    .FirstOrDefaultAsync(m => m.Id == id));

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

        public IActionResult AddItemTemp()
        {



            MedTempViewModel model = new MedTempViewModel
            {
                Dispensers = _combosHelper.GetComboDispensers(),
                Hoses = _combosHelper.GetComboHoses(0)
            };



            return View(model);
        }

        [HttpPost]
        public IActionResult AddItemTemp(MedTempViewModel model)
        {

            if (ModelState.IsValid != false)
            {
                MedTemp mov = new MedTemp
                {
                    Detail = model.Detail,
                    Dispenser = _context.Dispensers.Find(model.DispenserId),
                    Hose = _context.Hoses.Find(model.HoseId),
                    Id = 0,
                    Md1 = model.Md1,
                    Md2 = model.Md2,
                    Md3 = model.Md3
                };
                _context.Add(mov);
                _context.SaveChanges();

                return RedirectToAction(nameof(Medidas));
            }



            return View(model);
        }

        public IActionResult AddIMeaItem(int id)
        {
            MedTempViewModel model = new MedTempViewModel
            {
                Dispensers = _combosHelper.GetComboDispensers(),
                Hoses = _combosHelper.GetComboHoses(0),
                IdMeaDips = id
            };



            return View(model);
        }

        [HttpPost]
        public IActionResult AddIMeaItem(MedTempViewModel model)
        {

            if (ModelState.IsValid != false)
            {

                MeaDisp meaDisp = _context.MeaDisps.Include(m => m.Station)
                    .Include(m => m.Seraphin)
                    .Include(m => m.User)
                    .Include(m => m.MeaItems)
                    .ThenInclude(m => m.Dispenser)
                    .Include(m => m.MeaItems)
                    .ThenInclude(m => m.Hose)
                    .FirstOrDefault(m => m.Id == model.IdMeaDips);



                MeaItem var = new MeaItem
                {
                    Detail = model.Detail,
                    Dispenser = _context.Dispensers.Find(model.DispenserId),
                    Hose = _context.Hoses.Find(model.HoseId),
                    Id = 0,
                    Md1 = model.Md1,
                    Md2 = model.Md2,
                    Md3 = model.Md3
                };
                meaDisp.MeaItems.Add(var);
                _context.Update(meaDisp);
                _context.SaveChanges();

                return RedirectToAction($"{nameof(DetailsMeaDisp)}/{model.IdMeaDips}");
            }



            return View(model);
        }

        public async Task<IActionResult> Medidas()
        {
           
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            MeaDispViewModel measurement = new MeaDispViewModel
            {
                Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault(),
                Seraphin = _context.Seraphin.Where(s => s.Station.Id == user.Station.Id).FirstOrDefault(),
                User = user,
                Date = DateTime.Now,
                MedTemps = _context.MedTemps
                .Include(m => m.Dispenser)
                .Include(m => m.Hose)
                .OrderBy(m => m.Dispenser.Name)
                .ThenBy(m => m.Hose.Number)
                .ToList(),
                Number=NextNumber()

            };
            return View(measurement);
        }

        [HttpPost]
        public async Task<IActionResult> Medidas(MeaDispViewModel model)
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (ModelState.IsValid != false)
            {                
                model.Id = 0;
                model.MeaItems = _context.MedTemps.Include(m => m.Dispenser).Include(m => m.Hose).ToList().Select(t => new MeaItem
                {
                    Detail = t.Detail,
                    Dispenser = t.Dispenser,
                    Hose = t.Hose,
                    Id = 0,
                    Md1 = t.Md1,
                    Md2 = t.Md2,
                    Md3 = t.Md3
                }).ToList();               
                if (model.MeaItems.Count > 0) {
                        MeaDisp meaDisp = new MeaDisp
                        {
                            Date = model.Date,
                            EndHour = model.EndHour,
                            Id = 0,
                            MeaItems = model.MeaItems,
                            Number = model.Number,
                            Observation = model.Observation,
                            StartHour = model.StartHour,
                            User = user,
                            Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault(),
                            Seraphin = _context.Seraphin.Where(s => s.Station.Id == user.Station.Id).FirstOrDefault()
                        };
                        _context.Add(meaDisp);
                        List<MedTemp> aux = _context.MedTemps.ToList();
                        foreach (MedTemp item in aux)
                        {
                            _context.MedTemps.Remove(item);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Medidas));
                }
                ViewBag.Error = "You must insert a measurement to the list";
                List<MedTemp> medTemps = new List<MedTemp>();
                model.MedTemps = medTemps;
                model.Seraphin = _context.Seraphin.Where(s => s.Station.Id == user.Station.Id).FirstOrDefault();
                model.Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault();
                model.User = user;
                return View(model);
            }          
           
            model.MedTemps = _context.MedTemps.Include(m=>m.Hose).Include(m => m.Dispenser).ToList();
            model.Seraphin = _context.Seraphin.Where(s => s.Station.Id == user.Station.Id).FirstOrDefault();
            model.Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault();
            model.User = user;
            return View(model);

        }

        public async Task<IActionResult> UpdateMeaDip(MeaDisp model)
        {
            if (ModelState.IsValid != false)
            {
                MeaDisp meaDisp = _context.MeaDisps.Include(m => m.Station)
                 .Include(m => m.Seraphin)
                 .Include(m => m.User)
                 .Include(m => m.MeaItems)
                 .ThenInclude(m => m.Dispenser)
                 .Include(m => m.MeaItems)
                 .ThenInclude(m => m.Hose)
                 .FirstOrDefault(m => m.Id == model.Id);

                meaDisp.Date = model.Date;
                meaDisp.Observation = model.Observation;
                meaDisp.Number = model.Number;
                meaDisp.EndHour = model.EndHour;
                meaDisp.StartHour = model.StartHour;

                _context.Update(meaDisp);
                await _context.SaveChangesAsync();

                return RedirectToAction($"{nameof(DetailsMeaDisp)}/{meaDisp.Id}");
            }

            return RedirectToAction($"{nameof(DetailsMeaDisp)}/{model.Id}");
        }

        public async Task<IActionResult> DetailsDispenser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DispenserEntity dispenser = await _context.Dispensers.Include(s => s.Hoses)
               .FirstOrDefaultAsync(d => d.Id == id);
            StationEntity station = _context.Stations.Include(s => s.Dispensers).Where(s => s.Dispensers.Contains(dispenser)).FirstOrDefault();
            dispenser.IdStation = station.Id;
           
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

        public async Task<IActionResult> EditHose(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            HoseEntity hose = await _context.Hoses.FindAsync(id);
            if (hose == null)
            {
                return NotFound();
            }

           
            return View(hose);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHose(int id, HoseEntity hose)
        {
            if (ModelState.IsValid)
            {
                if (id != hose.Id)
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
                   
                    _context.Update(hose);
                    await _context.SaveChangesAsync();

                    DispenserEntity disp = _context.Dispensers
                   .Include(d => d.Hoses)
                   .Where(d => d.Hoses.Contains(hose))
                   .FirstOrDefault();

                    return RedirectToAction($"{nameof(DetailsDispenser)}/{disp.Id}");

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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles ="Admin")]
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

        public async Task<IActionResult> DeleteMedItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MedTemp temp = await _context.MedTemps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temp == null)
            {
                return NotFound();
            }
            _context.MedTemps.Remove(temp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Medidas));
        }

        public async Task<IActionResult> DeleteDispenser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DispenserEntity dispenser = await _context.Dispensers
                .Include(d=>d.Hoses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dispenser == null)
            {
                return NotFound();
            }

            _context.Dispensers.Remove(dispenser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteMeaDisp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeaDisp meaDisp = await _context.MeaDisps
                 .Include(m => m.Station)
                    .Include(m => m.Seraphin)
                    .Include(m => m.User)
                    .Include(m => m.MeaItems)
                    .ThenInclude(m => m.Dispenser)
                    .Include(m => m.MeaItems)
                    .ThenInclude(m => m.Hose)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meaDisp == null)
            {
                return NotFound();
            }

            _context.MeaDisps.Remove(meaDisp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexMeaDisp));
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
            DispenserEntity disp = _context.Dispensers
              .Include(d => d.Hoses)
              .Where(d => d.Hoses.Contains(hose))
              .FirstOrDefault();

            _context.Hoses.Remove(hose);
            await _context.SaveChangesAsync();

          

            return RedirectToAction($"{nameof(DetailsDispenser)}/{disp.Id}");
        }

        public async Task<IActionResult> DeleteMeaItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeaItem meaItem = await _context.MeaItems
                .FirstOrDefaultAsync(m => m.Id == id);

            MeaDisp result = _context.MeaDisps
                .Include(m => m.MeaItems)
                .Where(m => m.MeaItems.Contains(meaItem)).FirstOrDefault();


            if (meaItem == null)
            {
                return NotFound();
            }

            _context.MeaItems.Remove(meaItem);
            await _context.SaveChangesAsync();


            return RedirectToAction($"{nameof(DetailsMeaDisp)}/{result.Id}");
        }

        private bool StationEntityExists(int id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }

        public JsonResult GetHoses(int dispenserId)
        {
            DispenserEntity dispenser = _context.Dispensers
                 .Include(d => d.Hoses)
                 .FirstOrDefault(d => d.Id == dispenserId);
            if (dispenser == null)
            {
                return null;
            }
            List<HoseEntity> aux = dispenser.Hoses.ToList();

            List<HoseEntity> disps = _context.MedTemps.Include(m => m.Hose).Select(t => new HoseEntity
            {
                Id = t.Hose.Id,
                Number = t.Hose.Number,
                Type = t.Hose.Type
            }).ToList();
            if (disps != null)
            {
                foreach (HoseEntity item in disps)
                {
                    HoseEntity test = _context.Hoses.Find(item.Id);
                    aux.Remove(test);
                }
            }

            return Json(aux.OrderBy(h => h.Number));
        }

        

        public JsonResult GetHosesItem(int dispenserId, int meaDispId)
        {
            DispenserEntity dispenser = _context.Dispensers
                 .Include(d => d.Hoses)
                 .FirstOrDefault(d => d.Id == dispenserId);
            if (dispenser == null)
            {
                return null;
            }
            List<HoseEntity> aux = dispenser.Hoses.ToList();

            MeaDisp disp = _context.MeaDisps.Include(m => m.MeaItems)
                .ThenInclude(m => m.Hose).FirstOrDefault(m => m.Id == meaDispId);

            List<HoseEntity> disps = disp.MeaItems.Select(t => new HoseEntity
            {
                Id=t.Hose.Id,
                Number=t.Hose.Number,
                Type=t.Hose.Type
            }).ToList();



            if (disps != null)
            {
                foreach (HoseEntity item in disps)
                {
                    HoseEntity test = _context.Hoses.Find(item.Id);
                    aux.Remove(test);
                }
            }

            return Json(aux.OrderBy(h => h.Number));
        }


        public JsonResult GetCompartments(int compid)
        {
           

            

            return Json(_context.Compartments.ToList());
        }


        public int  NextNumber()
        {
            int number = 0;
            var result = _context.MeaDisps.ToList();
            if (result.Count > 0)
            {
                number = (from m in result
                          select m.Number).Max();
            }
            number++;
            return number;
        }

    }
}
