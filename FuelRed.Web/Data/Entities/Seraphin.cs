using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class Seraphin
    {
        public int Id { get; set; }

        public int Gauge { get; set; }

        public int Certifacate { get; set; }

        public int validity { get; set; }

        public StationEntity Station { get; set; }

        [NotMapped]
        public int IdStation { get; set; }
    }
}
