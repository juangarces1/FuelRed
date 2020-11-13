using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class Driver
    {
        public int Id { get; set; }

       
        [Required(ErrorMessage = "You must be enter a {0}")]
        public int Document { get; set; }

       
        [Required(ErrorMessage = "You must be enter a {0}")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must be enter a {0}")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You must be enter a {0}")]
        public string PhoneNumber { get; set; }

        public StationEntity Station { get; set; }

        [NotMapped]
        public int IdStation { get; set; }
    }
}
