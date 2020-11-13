using FuelRed.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Models
{
    public class MeaDispViewModel : MeaDisp
    {
        public ICollection<MedTemp> MedTemps { get; set; }
    }
}
