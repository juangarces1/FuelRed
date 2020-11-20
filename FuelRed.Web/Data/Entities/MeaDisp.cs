using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class MeaDisp
    {
        public int Id { get; set; }

        public StationEntity Station { get; set; }

        public UserEntity User { get; set; }

        public Seraphin Seraphin { get; set; }

        [Required(ErrorMessage = "You must select a {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You must select a {0}")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = false)]
        [Display(Name ="Start Hour")]
        public DateTime StartHour { get; set; }

        [Required(ErrorMessage ="You must select a {0}")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = false)]
        [Display(Name = "End Hour")]
        public DateTime EndHour { get; set; }

        [Display(Name = "Measurements")]
        public int NumberMeasurements => MeaItems == null ? 0 : MeaItems.Count;

        [Required(ErrorMessage = "You must select a {0}")]
        public int Number { get; set; }

        public string Observation { get; set; }

        public ICollection<MeaItem> MeaItems { get; set; }

    }
}
