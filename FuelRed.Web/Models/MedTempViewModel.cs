using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Models
{
    public class MedTempViewModel
    {
        [Required(ErrorMessage = "You must enter a {0} ")]
        [Display(Name = "Measuarement 1")]
        public decimal Md1 { get; set; }

        [Required(ErrorMessage = "You must enter  a{0} ")]
        [Display(Name = "Measuarement 2")]
        public decimal Md2 { get; set; }

        [Required(ErrorMessage = "You must enter a {0} ")]
        [Display(Name = "Measuarement 3")]
        public decimal Md3 { get; set; }


        public IEnumerable<SelectListItem> Dispensers { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must select a Dispenser.")]
        [Display(Name = "Dispenser")]
        public int DispenserId { get; set; }


        public IEnumerable<SelectListItem> Hoses { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must select a Hose.")]
        [Display(Name = "Hose")]
        public int HoseId { get; set; }

        [Required(ErrorMessage = "You must enter {0} ")]
        [Display(Name = "Present Water/Sediment")]
        public string Detail { get; set; }

       
        public int IdMeaDips { get; set; }
    }
}
