using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelRed.Web.Data;
using FuelRed.Web.Models;
using FuelRed.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

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