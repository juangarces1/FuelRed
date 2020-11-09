using FuelRed.Common.Enums;
using FuelRed.Models.Common;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        private readonly IConverterHelper _converterHelper;

        private readonly IConfiguration _configuration;

        public AccountController(
            DataContext dataContext,
            IUserHelper userHelper,

            IConverterHelper converterHelper,

            IConfiguration configuration)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;

            _converterHelper = converterHelper;

            _configuration = configuration;
        }



        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromBody] EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);


            UserEntity userEntity = await _userHelper.GetUserAsync(request.Email);
            if (userEntity == null)
            {
                return NotFound("usuario no existe");
            }

            return Ok(_converterHelper.ToUserResponse(userEntity));
        }

       

       
    
    }
}
