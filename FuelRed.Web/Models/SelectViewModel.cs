using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FuelRed.Web.Models
{
    public class SelectViewModel
    {
        public IEnumerable<SelectListItem> Drivers { get; set; }

        [Display(Name ="Driver")]
        [Range(1, 100, ErrorMessage = "You must select a {0}")]
        public int DriverId { get; set; }

        public IEnumerable<SelectListItem> Trucks { get; set; }

        [Display(Name = "Truck")]
        [Range(1, 100, ErrorMessage = "You must select a {0}")]
        public int TruckId { get; set; }
    }
}
