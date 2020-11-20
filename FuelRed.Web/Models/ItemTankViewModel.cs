using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Models
{
    public class ItemTankViewModel
    {
        public int Id { get; set; }

        public int TankNumber { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "You must select a {0}.")]
        [Display(Name = "Fuel")]
        public int type { get; set; }

        public int Compartment { get; set; }

        public IEnumerable<SelectListItem> Tanks { get; set; }

        public IEnumerable<SelectListItem> Tipes { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must select a Tank.")]
        [Display(Name = "Tank")]
        public int IdTank { get; set; }

        public IEnumerable<SelectListItem> Compartments { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must select a Comparment.")]
        [Display(Name = "Comparment")]
        public int IdCompartment { get; set; }
           
        public TypeFuel TypeFuel { get; set; }

        [Display(Name = "Sample with sediment?")]
        public bool Sediments { get; set; }

        [Display(Name = "Sample with diferent color?")]
        public bool Color { get; set; }

        [Display(Name = "Sample with Water?")]
        public bool Water { get; set; }

        public int DriverId { get; set; }

        public int TruckId { get; set; }

    }
}
