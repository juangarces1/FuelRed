using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Controllers
{
    public class DownloadController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;

        public DownloadController(DataContext context,
                                    IUserHelper userHelper,
                                    ICombosHelper combosHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
        }

        [HttpGet]
        public async Task<IActionResult> SelectInfo()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            SelectViewModel select = new SelectViewModel
            {
                Drivers = _combosHelper.GetDriverStation(user.Station),
                Trucks = _combosHelper.GetTrucksStation(user.Station)
            };
            return View(select);
        }

        [HttpPost]
        public async Task<IActionResult> SelectInfo(SelectViewModel select)
        { 
            if (ModelState.IsValid)
            {
                return RedirectToAction($"{select.DriverId}/{nameof(Index)}/{select.TruckId}");
            }

            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            select.Drivers = _combosHelper.GetDriverStation(user.Station);
            select.Trucks = _combosHelper.GetTrucksStation(user.Station);
            return View(select);
            
        }

        
        public async Task<IActionResult> Index(int DriverId, int TruckId)
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            DownloadviewModel download = new DownloadviewModel
            {
                Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault(),
                Truck = await _context.Trucks.FindAsync(TruckId),
                Driver = await _context.Drivers.FindAsync(DriverId),
                User = user,
                Date = DateTime.Now,
                ItemTankTemps = _context.ItemTankTemps
                               .Include(i => i.Compartment)
                               .Include(i => i.Tank)
                               .Where(i => i.TruckId == TruckId)
                               .ToList(),
                Number = NextNumber(),
                UnitTemps = _context.UnitTemps.ToList(),
                DriverId = DriverId,
                TruckId = TruckId
              
            };
            return View(download);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DownloadviewModel download)
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (_context.ItemTankTemps.Where(i => i.TruckId == download.TruckId).ToList().Count == 0)
                {
                    ViewBag.Error = "You must enter a Tank";

                    download.Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault();
                    download.Truck = await _context.Trucks.FindAsync(download.TruckId);
                    download.Driver = await _context.Drivers.FindAsync(download.DriverId);
                    download.User = user;

                    download.ItemTankTemps = _context.ItemTankTemps
                                       .Include(i => i.Compartment)
                                       .Include(i => i.Tank)
                                       .Where(i => i.TruckId == download.TruckId)
                                       .ToList();

                    download.UnitTemps = _context.UnitTemps.ToList();
                    return View(download);
                }
                if (_context.UnitTemps.ToList().Count == 0)
                {
                    ViewBag.Error = "You must enter a Storage Tank Measurement";
                    download.Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault();
                    download.Truck = await _context.Trucks.FindAsync(download.TruckId);
                    download.Driver = await _context.Drivers.FindAsync(download.DriverId);
                    download.User = user;

                    download.ItemTankTemps = _context.ItemTankTemps
                                       .Include(i => i.Compartment)
                                       .Include(i => i.Tank)
                                       .Where(i => i.TruckId == download.TruckId)
                                       .ToList();

                    download.UnitTemps = _context.UnitTemps.ToList();
                    return View(download);
                }



            }
            download.Station = _context.Stations.Where(s => s.Id == user.Station.Id).FirstOrDefault();
            download.Truck = await _context.Trucks.FindAsync(download.TruckId);
            download.Driver = await _context.Drivers.FindAsync(download.DriverId);
            download.User = user;

            download.ItemTankTemps = _context.ItemTankTemps
                               .Include(i => i.Compartment)
                               .Include(i => i.Tank)
                               .Where(i => i.TruckId == download.TruckId)
                               .ToList();
            
            download.UnitTemps = _context.UnitTemps.ToList();
              
            return View(download);

        }
        public IActionResult AddItemTemp(int DriverId, int TruckId)
        {
            ItemTankViewModel model = new ItemTankViewModel
            {
                Tanks = _combosHelper.GetComboTanks(TruckId),
                Tipes = _combosHelper.GetComboTypesFuel(),
                DriverId=DriverId,
                TruckId=TruckId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddItemTemp(ItemTankViewModel model)
        {
            if (ModelState.IsValid)
            {
                ItemTankTemp item = new ItemTankTemp
                {
                    Id = 0,
                    Compartment = _context.Compartments.Find(model.IdCompartment),
                    Fuel = model.TypeFuel.ToString(),
                    Tank = _context.TruckTanks.Find(model.IdTank),
                    TypeFuel = model.TypeFuel,
                    Sediments = model.Sediments,
                    Color = model.Color,
                    Water = model.Water,
                    TruckId = model.TruckId
                    
                };
                switch (model.type)
                {
                    case 1:
                        item.TypeFuel = TypeFuel.Diesel;
                        item.Fuel = TypeFuel.Diesel.ToString();
                        break;
                    case 2:
                        item.TypeFuel = TypeFuel.Regular;
                        item.Fuel = TypeFuel.Regular.ToString();
                        break;
                    case 3:
                        item.TypeFuel = TypeFuel.Super;
                        item.Fuel = TypeFuel.Super.ToString();
                        break;
                    case 4:
                        item.TypeFuel = TypeFuel.Exonerado;
                        item.Fuel = TypeFuel.Exonerado.ToString();
                        break;
                    default:
                        break;
                }
                _context.Add(item);
                _context.SaveChanges();

                return RedirectToAction($"{model.DriverId}/{nameof(Index)}/{model.TruckId}");
            }

            return View(model);

        }

        public IActionResult AddUnitTemp(int DriverId, int TruckId)
        {
            UnitTempViewModel model = new UnitTempViewModel 
            { 
                DriverId=DriverId,
                TruckId=TruckId
            };
           
            return View(model);
        }

        [HttpPost]
        public IActionResult AddUnitTemp(UnitTempViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                UnitTemp temp = new UnitTemp
                {
                    Buy=model.Buy,
                    EndLts=model.EndLts,
                    EndPulg=model.EndPulg,
                    Fuel=model.Fuel,
                    Id=0,
                    StartLts=model.StartLts,
                    StartPulg=model.StartPulg
                   
                };

                switch (model.Fuel)
                {
                    case "1":
                        temp.TypeFuel = TypeFuel.Regular;
                        break;

                    case "0":
                        temp.TypeFuel = TypeFuel.Diesel;
                        break;

                    case "2":
                        temp.TypeFuel = TypeFuel.Super;
                        break;
                    case "3":
                        temp.TypeFuel = TypeFuel.Exonerado;
                        break;
                }

                _context.UnitTemps.Add(temp);
                _context.SaveChanges();

                return RedirectToAction($"{model.DriverId}/{nameof(Index)}/{model.TruckId}");
            }

            return View(model);

        }
        

        public async Task<IActionResult> DeleteUnitTemp(int DriverId, int TruckId, int id)
        {
            UnitTemp item = _context.UnitTemps.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.UnitTemps.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction($"{DriverId}/{nameof(Index)}/{TruckId}");
        }
        public async Task<IActionResult> DeleteItemTemp(int DriverId, int TruckId, int id)
        {
            ItemTankTemp item = _context.ItemTankTemps.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ItemTankTemps.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction($"{DriverId}/{nameof(Index)}/{TruckId}");
        }

        public JsonResult GetCompartments(int tankid)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            TruckTank ta = _context.TruckTanks.Include(t => t.Compartments).Where(t => t.Id == tankid).FirstOrDefault();
            List<Compartment> aux = ta.Compartments.ToList();

            if (ta == null)
            {
                return null;
            }        
            return Json(aux.OrderBy(c => c.Number));
        }

        public int NextNumber()
        {
            int number = 0;
            List<Download> result = _context.Downloads.ToList();
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
