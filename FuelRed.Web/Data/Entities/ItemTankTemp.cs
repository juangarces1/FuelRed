using FuelRed.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Data.Entities
{
    public class ItemTankTemp
    {
        public int Id { get; set; }

        public TruckTank Tank { get; set; }

        public string Fuel { get; set; }

       
        public TypeFuel TypeFuel { get; set; }

        public Compartment Compartment { get; set; }

        [Display(Name = "Sample with sediment?")]
        public bool Sediments { get; set; }

        [Display(Name = "Sample with diferent color?")]
        public bool Color { get; set; }

        [Display(Name = "Sample with Water?")]
        public bool Water { get; set; }

        public int TruckId { get; set; }
    }
}
