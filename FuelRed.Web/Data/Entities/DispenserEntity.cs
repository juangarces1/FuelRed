using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace FuelRed.Web.Data.Entities
{
    public class DispenserEntity
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<HoseEntity> Hoses { get; set; }      

        [DisplayName("Hoses Number")]
        public int HosesNumber => Hoses == null ? 0 : Hoses.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdStation { get; set; }

       
    }
}
