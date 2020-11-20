using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Models
{
    public class DownloadviewModel : Download
    {
       public ICollection<ItemTankTemp> ItemTankTemps { get; set; }


        public ICollection<UnitTemp> UnitTemps { get; set; }


        public int DriverId { get; set; }

        public int TruckId { get; set; }
    }
}
