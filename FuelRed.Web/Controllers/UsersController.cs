using FuelRed.Web.Data;
using FuelRed.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FuelRed.Web.Controllers
{

    public class UsersController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public UsersController(DataContext dataContext,
                                IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }




    }
}