using FuelRed.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class ItemTank
    {
        public int Id { get; set; }

        public TruckTank Tank { get; set; }

        public Truck Truck { get; set; }

        public TypeFuel TypeFuel { get; set; }

        public Compartment Compartment { get; set; }

        [NotMapped]
        public  int IdDownload { get; set; }
    }
}
