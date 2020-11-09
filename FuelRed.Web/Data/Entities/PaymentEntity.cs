using FuelRed.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => Date.ToLocalTime();

        public UserEntity User { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Amount { get; set; }

        public BankEntity Bank { get; set; }

        [Required (ErrorMessage ="The field {0} is mandatory")]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; }
       

        [Display(Name = "Currency Type")]
        public CurrencyType Currency { get; set; }

        [Display(Name = "Payment Status")]
        public PaymentStatus PaymentStatus { get; set; }

    }
}
