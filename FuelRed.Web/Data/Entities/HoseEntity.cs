using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class HoseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You must Select a {0}")]
        public string Type { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int Number { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdDispenser { get; set; }
    }
}
