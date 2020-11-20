using FuelRed.Web.Data.Entities;
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

        IEnumerable<SelectListItem> GetComboComparments(int idtank);

        IEnumerable<SelectListItem> GetComboTanks(int Idtruck);

        IEnumerable<SelectListItem> GetDriverStation(StationEntity station);

        IEnumerable<SelectListItem> GetTrucksStation(StationEntity station);

        IEnumerable<SelectListItem> GetComboTypesFuel();
    }
}
