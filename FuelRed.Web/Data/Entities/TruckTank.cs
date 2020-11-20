using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class TruckTank
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must be enter a {0}")]
        public int Number { get; set; }

        public ICollection<Compartment> Compartments { get; set; }

        [Display(Name ="Compartments")]
        public int CompartmentsNumber => Compartments == null ? 0 : Compartments.Count;
      

        [NotMapped]
        public int IdTruck { get; set; }
    }
}
