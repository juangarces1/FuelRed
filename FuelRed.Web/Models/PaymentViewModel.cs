using FuelRed.Common.Enums;
using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Models
{
    public class PaymentViewModel : PaymentEntity
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Visitor")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a bank.")]
        public int BannkId { get; set; }

        public IEnumerable<SelectListItem> Banks { get; set; }
        
    }
}
