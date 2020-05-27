using FuelRed.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data
{
    public class BankEntity
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string Name { get; set; }

       public ICollection<PaymentEntity> Payments { get; set; }


    }
}
