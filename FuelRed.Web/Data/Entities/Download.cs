using System;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class Download
    {

        public int Id { get; set; }

        public StationEntity Station { get; set; }

        public UserEntity User { get; set; }

        public Truck Truck { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = false)]
        [Display(Name = "Start Hour")]
        public DateTime StartHour { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = false)]
        [Display(Name = "End Hour")]
        public DateTime EndHour { get; set; }

        public int Number { get; set; }

        public string Observation { get; set; }


        [Display(Name = "Security(helmet, glasses, vest and globes)")]
        public bool Security { get; set; }

        [Display(Name = "Extinguishers in position (Minimum 2 fire extinguishers of 9KG)")]
        public bool Extinguisher { get; set; }

        [Display(Name = "Clear cistern exit")]
        public bool Exit { get; set; }

        [Display(Name = "Roped off tank area")]
        public bool Area { get; set; }

        [Display(Name = "The tank is leaking fuel (Open hatches)")]
        public bool CisternEscape { get; set; }

        [Display(Name = "Clean discharge spout container")]
        public bool Container { get; set; }

        [Display(Name = "The cistern possesses marched")]
        public bool Marched { get; set; }

        [Display(Name = "verify marched against invoice(RECOPE / CAMARA)")]
        public bool Recope { get; set; }

        [Display(Name = "Verification sample was taken")]
        public bool Sample { get; set; }



    }
}
