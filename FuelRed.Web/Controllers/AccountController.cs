using Microsoft.AspNetCore.Mvc;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelRed.Web.Data.Entities;
using FuelRed.Common.Enums;
using FuelRed.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace FuelRed.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly IImageHelper _imageHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _context;

        public AccountController(IUserHelper userHelper,
                                 IImageHelper imageHelper,
                                 ICombosHelper combosHelper,
                                 DataContext context)
        {
            _userHelper = userHelper;
            _imageHelper = imageHelper;
            _combosHelper = combosHelper;
            _context = context;
        }

        [Authorize(Roles = "Admin")]       
        public async Task<IActionResult> Index()
        {
            var usero = await _userHelper.GetUserAsync(User.Identity.Name);
            if (usero.UserType == UserType.Admin)
            {
                var users = await _userHelper.GetAllUsersAsync();
                var usersView = new List<UserViewModel>();
                foreach (var user in users)
                {
                    var userView = new UserViewModel
                    {
                        UserType = user.UserType,
                        Email = user.Email,
                        Name = user.FullName,
                        UserID = user.Id,

                    };
                    if (user.Station != null)
                    {
                        userView.Station = user.Station.Name;
                    }

                    if (userView.Email != "sebastian.garces23@gmail.com")
                    {
                        usersView.Add(userView);
                    }
                }
                
                return View(usersView);
            }
            

            if (usero.UserType == UserType.StationAdmin)
            {
                var users = await _userHelper.GetAllUsersByStationAsync(User.Identity.Name);
                var usersView = new List<UserViewModel>();
                foreach (var user in users)
                {
                    var userView = new UserViewModel
                    {
                        UserType = user.UserType,
                        Email = user.Email,
                        Name = user.FullName,
                        UserID = user.Id,
                        Station = user.Station.Name
                    };
                   
                    usersView.Add(userView);
                }
                return View(usersView);
            }
            else
            {
                return View("Index","Home");
            }
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginViewModel log = new LoginViewModel();
            return View(log);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email or password incorrect.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                Stations = _combosHelper.GetComboStations()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if (model.PictureFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.PictureFile, "Users");
                }

                UserEntity user = await _userHelper.AddUserAsync(model, path, UserType.User);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    model.Stations = _combosHelper.GetComboStations();
                    return View(model);
                }

                LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username
                };

                var result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            model.Stations = _combosHelper.GetComboStations();
            return View(model);
        
        }

        public async Task<IActionResult> Roles(string email)
        {
            UserEntity user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            TypeUserViewModel model = new TypeUserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                Stations = _combosHelper.GetComboStations(),
                StationId = user.Station.Id,
                UserType = user.UserType,
                Email = user.UserName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Roles(TypeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = model.PicturePath;

                if (model.PictureFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.PictureFile, "Users");
                }

                UserEntity user = await _userHelper.GetUserAsync(model.Email);
                string tipo = user.UserType.ToString();
                user.Document = model.Document;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.PicturePath = path;
                user.Station = await _context.Stations.FindAsync(model.StationId);
                user.UserType = model.UserType;
                await _userHelper.UpdateUserAsync(user);
                await _userHelper.AddUserToRoleAsync(user, model.UserType.ToString());
                await _userHelper.RemoveUserFromRoleAsync(user, tipo);
                return RedirectToAction("Index", "Account");
            }

            model.Stations = _combosHelper.GetComboStations();
            return View(model);
        }



        public async Task<IActionResult> ChangeUser()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            EditUserViewModel model = new EditUserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                Stations = _combosHelper.GetComboStations(),
                StationId = user.Station.Id
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = model.PicturePath;

                if (model.PictureFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.PictureFile, "Users");
                }

                UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);

                user.Document = model.Document;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.PicturePath = path;
                user.Station = await _context.Stations.FindAsync(model.StationId);

                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }

            model.Stations = _combosHelper.GetComboStations();
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserAsync(User.Identity.Name);
                if (user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return View(model);
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }





    }
}
