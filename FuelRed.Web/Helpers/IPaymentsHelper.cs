using FuelRed.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Helpers
{
    public interface IPaymentsHelper
    {
        Task<IQueryable<PaymentEntity>> GetPaymentsAsync(string email);
    }
}
