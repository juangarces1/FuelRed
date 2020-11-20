using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelRed.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboStations()
        {
            List<SelectListItem> list = _context.Stations.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Station...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboBanks()
        {
            List<SelectListItem> list = _context.Banks.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Bank...]",
                Value = "0"
            });

            return list;
        }


        public IEnumerable<SelectListItem> GetDriverStation(StationEntity station)
        {
            List<SelectListItem> list = _context.Drivers.Where(d => d.Station==station).Select(t => new SelectListItem
            {
                Text = t.FullName,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Driver...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetTrucksStation(StationEntity station)
        {
            List<SelectListItem> list = _context.Trucks.Where(d => d.Station == station).Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Truck...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboDispensers()
        {
            List<SelectListItem> list = _context.Dispensers.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Dispenser...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboHoses(int IdDispenser)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            DispenserEntity dispenser = _context.Dispensers.Include(h => h.Hoses)
                .FirstOrDefault(d => d.Id == IdDispenser);

            if (dispenser != null)
            {
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
                        aux.Remove(item);
                    }
                }

                list = dispenser.Hoses.Select(t => new SelectListItem
                {
                    Text = t.Type,
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }


            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Hose...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboComparments(int idtank)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            TruckTank tank = _context.TruckTanks.Include(t => t.Compartments)
                .FirstOrDefault(d => d.Id == idtank);

            if (tank != null)
            {
                List<Compartment> aux = tank.Compartments.ToList();
                List<Compartment> comps = _context.ItemTankTemps.Include(m => m.Compartment).Select(t => new Compartment
                {
                    Id = t.Compartment.Id,
                    Number = t.Compartment.Number,
                    Capacity = t.Compartment.Capacity


                }).ToList();

                if (comps != null)
                {
                    foreach (Compartment item in comps)
                    {
                        aux.Remove(item);
                    }
                }

                list = aux.Select(t => new SelectListItem
                {
                    Text = t.Capacity.ToString(),
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }


            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Hose...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTanks(int Idtruck)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            Truck truck = _context.Trucks.Include(t => t.Tanks)
                .FirstOrDefault(d => d.Id == Idtruck);

            if (truck != null)
            {
                List<TruckTank> aux = truck.Tanks.ToList();
                List<TruckTank> tanks = _context.ItemTankTemps.Include(m => m.Tank).Select(t => new TruckTank
                {
                    Id = t.Tank.Id,
                    Number = t.Tank.Number                  


                }).ToList();

                if (tanks != null)
                {
                    foreach (TruckTank item in tanks)
                    {
                        TruckTank taux = _context.TruckTanks.Find(item.Id);
                        aux.Remove(taux);
                    }
                }

                list = aux.Select(t => new SelectListItem
                {
                    Text = t.Number.ToString(),
                    Value = $"{t.Id}"
                })
                    .OrderBy(t => t.Text)
                    .ToList();
            }


            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Tank...]",
                Value = "0"
            });

            return list;
        }

        public  IEnumerable<SelectListItem> GetComboTypesFuel()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Fuel...]",
                Value = "-1"
            });
            int i = 1;
            foreach (var item in Enum.GetNames(typeof(TypeFuel)))
            {
                list.Insert(i, new SelectListItem
                {
                    Text = item,
                    Value = i.ToString()
                   
                });
                i++;

            }
           


            return list;
        }



    }
}
