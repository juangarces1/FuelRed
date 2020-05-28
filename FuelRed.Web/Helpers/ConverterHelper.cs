using FuelRed.Web.Data.Entities;
using FuelRed.Web.Models;

namespace FuelRed.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        public StationEntity ToStationEntity(StationViewModel model, string path, bool isNew)
        {
            return new StationEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name,
                Address = model.Address,
                LegalCertificate = model.LegalCertificate

            };
        }

        public StationViewModel ToStationViewModel(StationEntity stationEntity)
        {
            return new StationViewModel
            {
                Id = stationEntity.Id,
                LogoPath = stationEntity.LogoPath,
                Name = stationEntity.Name,
                Address = stationEntity.Address,
                LegalCertificate = stationEntity.LegalCertificate
            };
        }

        public ProductEntity ToProductEntity(ProductViewModel model, string path, bool isNew)
        {
            return new ProductEntity
            {
                Id = isNew ? 0 : model.Id,
                Description = model.Description,
                Price = model.Price,
                ImagePath = path,
                Station = model.Station

            };
        }

        public ProductViewModel ToProductViewModel(ProductEntity productEntity)
        {
            return new ProductViewModel
            {
                Id = productEntity.Id,
                Description = productEntity.Description,
                Price = productEntity.Price,
                ImagePath = productEntity.ImagePath,
                Station = productEntity.Station
            };
        }
    }
}
