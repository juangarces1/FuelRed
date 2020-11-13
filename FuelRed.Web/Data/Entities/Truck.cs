using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class Truck
    {
        public int Id { get; set; }

        [Display(Name = "License Plate")]
        [Required(ErrorMessage = "You must be enter a {0}")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "You must be enter a {0}")]
        public string Name { get; set; }

       
        [Required(ErrorMessage = "You must be enter a {0}")]
        
        public string Model { get; set; }

        [Display(Name ="Tank Plate")]
        [Required(ErrorMessage = "You must be enter a {0}")]
        public string TankPlate { get; set; }

        public StationEntity Station { get; set; }

        [NotMapped]
        public int IdStation { get; set; }

        public ICollection<TruckTank> Tanks { get; set; }

        public int TanksNumber => Tanks == null ? 0 : Tanks.Count;

    }
}
