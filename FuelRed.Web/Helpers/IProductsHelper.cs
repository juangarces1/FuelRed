using FuelRed.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Helpers
{
    public interface IProductsHelper
    {
        Task<IQueryable<ProductEntity>> GetProductsAsync(string email);
    }
}
