using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Models
{
    public class ProductViewModel : ProductEntity
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
