using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class HoseEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int Number { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdDispenser { get; set; }
    }
}
