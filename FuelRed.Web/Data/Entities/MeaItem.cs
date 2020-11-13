using System.ComponentModel.DataAnnotations.Schema;

namespace FuelRed.Web.Data.Entities
{
    public class MeaItem
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Md1 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Md2 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Md3 { get; set; }

        public DispenserEntity Dispenser { get; set; }

        public HoseEntity Hose { get; set; }

        public string Detail { get; set; }
    }
}
