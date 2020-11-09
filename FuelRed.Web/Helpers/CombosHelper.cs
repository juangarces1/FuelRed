using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        //public IEnumerable<SelectListItem> GetComboDispensers()
        //{
        //    List<SelectListItem> list = _context.Dispensers.Select(t => new SelectListItem
        //    {
        //        Text = t.Name,
        //        Value = $"{t.Id}"
        //    })
        //        .OrderBy(t => t.Text)
        //        .ToList();

        //    list.Insert(0, new SelectListItem
        //    {
        //        Text = "[Select a Dispenser...]",
        //        Value = "0"
        //    });

        //    return list;
        //}

        //public IEnumerable<SelectListItem> GetComboHoses(int IdDispenser)
        //{
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    DispenserEntity dispenser = _context.Dispensers.Include(h => h.Hoses)
        //        .FirstOrDefault(d => d.Id == IdDispenser);

        //    if (dispenser != null) { 
        //        list = dispenser.Hoses.Select(t => new SelectListItem
        //        {
        //            Text = t.Type,
        //            Value = $"{t.Id}"
        //        })
        //            .OrderBy(t => t.Text)
        //            .ToList();
        //    }


        //    list.Insert(0, new SelectListItem
        //    {
        //        Text = "[Select a Hose...]",
        //        Value = "0"
        //    });

        //    return list;
        //}

        public IEnumerable<SelectListItem> GetComboBanks()
        {
            List<SelectListItem> list = _context.Banks.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = $"{b.Id}"
            })
                .OrderBy(b => b.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Bank...]",
                Value = "0"
            });

            return list;
        }



    }
}
