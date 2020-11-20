using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class Compartment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must be enter a {0}")]
        public int Number { get; set; }

        [Required(ErrorMessage = "You must be enter a {0}")]
        public int Capacity { get; set; }    

        [NotMapped]
        public int IdTank { get; set; }
    }
}
