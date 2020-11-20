using FuelRed.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Models
{
    public class UnitTempViewModel : Unit
    {
        [Required(ErrorMessage = "You must select a fuel")]
        public string Fuel { get; set; }

        public int DriverId { get; set; }

        public int TruckId { get; set; }
    }
}
