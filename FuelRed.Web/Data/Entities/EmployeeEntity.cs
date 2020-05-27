using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Data.Entities
{
    public class EmployeeEntity

    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter {0}")]
        public string LastName { get; set; }  
      

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        public ICollection<TransactionEntity> TransactionEntities { get; set; }

        public StationEntity Station { get; set; }







    }
}
