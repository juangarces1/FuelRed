using FuelRed.Web.Data.Entities;
using FuelRed.Web.Models;

namespace FuelRed.Web.Helpers
{
    public interface IConverterHelper
    {
        StationEntity ToStationEntity(StationViewModel model, string path, bool isNew);

        StationViewModel ToStationViewModel(StationEntity stationEntity);

        ProductEntity ToProductEntity(ProductViewModel model, string path, bool isNew);

        ProductViewModel ToProductViewModel(ProductEntity productEntity);
    }
}

