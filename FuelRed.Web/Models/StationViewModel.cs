using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Models
{
    public class StationViewModel : StationEntity
    {
        [Display(Name ="Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
