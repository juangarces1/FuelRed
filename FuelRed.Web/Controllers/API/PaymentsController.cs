using FuelRed.Common;
using FuelRed.Common.Models;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FuelRed.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public PaymentsController(DataContext context, IUserHelper userHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        [Route("GetPayments")]
        public async Task<IActionResult> GetPayments([FromBody] PaymentRequest payment)
        {
            var user = await _userHelper.GetUserAsync(payment.UserId);
            if (user == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "no existe el usuario"
                });
            }
            List<PaymentEntity> list =  _context.Payments.Where(p => p.User == user).ToList();
            List<PaymentResponse> lista = new List<PaymentResponse>();
            foreach (var item in list)
            {                
                lista.Add(_converterHelper.ToPaymentResponse(item));
            }
            return Ok(lista);

        }
    }
}
