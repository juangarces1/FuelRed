using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string Grade { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [MinLength(1, ErrorMessage = "The Field {0} must have min {1} characters")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public decimal Volumen { get; set; }


        [Display(Name = "Legal Certificate")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string Dispenser { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [MinLength(3, ErrorMessage = "The Field {0} must have min {1} characters")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public decimal Price { get; set; }

        public decimal Total => Price * Volumen;

        public StationEntity Station { get; set; }

        public EmployeeEntity Employee { get; set; }


    }
}
