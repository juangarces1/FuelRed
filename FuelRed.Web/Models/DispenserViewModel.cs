using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Models
{
    public class DispenserViewModel : DispenserEntity
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Visitor")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a bank.")]
        public int HoseId { get; set; }

      
    }
}
