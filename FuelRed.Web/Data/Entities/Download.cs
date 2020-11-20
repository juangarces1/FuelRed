using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class Download
    {

        public int Id { get; set; }

        public StationEntity Station { get; set; }

        public UserEntity User { get; set; }

        public Truck Truck { get; set; }

      
        public Driver  Driver { get; set; }

        [Required (ErrorMessage ="You must enter a {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Hour")]
        public DateTime StartHour { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Hour")]
        public DateTime EndHour { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        public int Number { get; set; }

        public string Observation { get; set; }


        public ICollection<ItemTank> ItemTanks { get; set; }

        [Display(Name = "Security(helmet, glasses, vest and globes)")]
        public bool Security { get; set; }

        [Display(Name = "Extinguishers in position (Minimum 2 fire extinguishers of 9KG)")]
        public bool Extinguisher { get; set; }

        [Display(Name = "Clear cistern exit")]
        public bool Exit { get; set; }

        [Display(Name = "Cistern connected to ground")]
        public bool ground { get; set; }

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
