using FuelRed.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class Unit
    {
        public int Id { get; set; }

        [Display(Name = "Fuel")]
        public TypeFuel TypeFuel { get; set; }

        [Display(Name = "Start Lts")]
        public int StartLts { get; set; }

        [Display(Name = "Final Lts")]
        public int EndLts { get; set; }

        [Display(Name = "Start M.Pulg/cm")]
        public int StartPulg { get; set; }

        [Display(Name = "Final M.Pulg/cm")]
        public int EndPulg { get; set; }

        [Display(Name = "Buy")]
        public int Buy { get; set; }


        [Display(Name = "Diff Lts")]
        public int DifferenceLts => EndLts - StartLts;

        [Display(Name = "Diff Lts")]
        public int DifferenceTotal => DifferenceLts - Buy;

       
    }
}
