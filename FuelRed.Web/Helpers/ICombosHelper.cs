using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FuelRed.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboStations();

        IEnumerable<SelectListItem> GetComboBanks();

        IEnumerable<SelectListItem> GetComboDispensers();

        IEnumerable<SelectListItem> GetComboHoses(int IdDispenser);


    }
}
