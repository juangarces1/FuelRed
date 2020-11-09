using FuelRed.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Helpers
{
     public interface IDispenserHelper
    {
        Task<IQueryable<DispenserEntity>> GetDispensersAsync(string email);
    }
}
