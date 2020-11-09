using FuelRed.Common.Models;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Models;
using Soccer.Common.Models;
using System.Threading.Tasks;

namespace FuelRed.Web.Helpers
{
    public interface IConverterHelper
    {
        StationEntity ToStationEntity(StationViewModel model, string path, bool isNew);

        StationViewModel ToStationViewModel(StationEntity stationEntity);

        ProductEntity ToProductEntity(ProductViewModel model, string path, bool isNew);

        ProductViewModel ToProductViewModel(ProductEntity productEntity);

        PaymentViewModel ToPaymentViewModel(PaymentEntity paymentEntity);

       Task<PaymentEntity> ToPaymentEntityAsync(PaymentViewModel model, string email, bool isNew);

        UserResponse ToUserResponse(UserEntity user);

        PaymentResponse ToPaymentResponse(PaymentEntity payment);

    }
}

