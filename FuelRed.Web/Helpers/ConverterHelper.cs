using FuelRed.Web.Data.Entities;
using FuelRed.Web.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using FuelRed.Web.Data;
using Soccer.Common.Models;
using FuelRed.Common.Models;

namespace FuelRed.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly IUserHelper _userHelper;
        private readonly DataContext _dataContext;

        public ConverterHelper(IUserHelper userHelper, DataContext dataContext)
        {
            _userHelper = userHelper;
            _dataContext = dataContext;
        }
        public StationEntity ToStationEntity(StationViewModel model, string path, bool isNew)
        {
            return new StationEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name,
                Address = model.Address,
                LegalCertificate = model.LegalCertificate,
                LegalName=model.LegalName

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
                LegalCertificate = stationEntity.LegalCertificate,
                LegalName = stationEntity.LegalName
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

        public async Task<PaymentEntity> ToPaymentEntityAsync(PaymentViewModel model, string email, bool isNew)
        {
            UserEntity user = await _userHelper.GetUserAsync(email);
            return new PaymentEntity
            {
                Id = isNew ? 0 : model.Id,
                Amount = model.Amount,
                Bank = _dataContext.Banks.Find(model.BannkId),
                User = user,
                Date = model.Date,
                Currency = model.Currency,
                DocumentNumber = model.DocumentNumber,
                PaymentStatus=model.PaymentStatus,
                

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

        public PaymentViewModel ToPaymentViewModel(PaymentEntity paymentEntity)
        {
            return new PaymentViewModel
            {
                Id = paymentEntity.Id,         
                Amount = paymentEntity.Amount,
                Bank = paymentEntity.Bank,
                User = paymentEntity.User,
                Date = paymentEntity.Date,
                Currency = paymentEntity.Currency,
                DocumentNumber = paymentEntity.DocumentNumber,
                PaymentStatus = paymentEntity.PaymentStatus,
                BannkId=paymentEntity.Bank.Id,
                
            };
        }

        public UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,               
                UserType = user.UserType
            };
        }

       public PaymentResponse ToPaymentResponse(PaymentEntity payment)
        {
            if (payment == null)
            {
                return null;
            }

            return new PaymentResponse
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                Date=payment.Date,
                DocumentNumber=payment.DocumentNumber,
                Id=payment.Id,
                PaymentStatus=payment.PaymentStatus
            };
       }

    }
}
