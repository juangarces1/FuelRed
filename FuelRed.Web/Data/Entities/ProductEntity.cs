using System;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
      

        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
      
        [Required(ErrorMessage = "You must enter {0}")]
        public string Description { get; set; }         

     
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "the {0} field is mandatory")]
        public decimal Price { get; set; }


        public StationEntity Station { get; set; }
    }
}
