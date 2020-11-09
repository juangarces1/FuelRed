using FuelRed.Common.Enums;
using FuelRed.Web.Data;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly DataContext _context;
        private readonly IPaymentsHelper _paymentsHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public PaymentsController(DataContext context, 
                                    IPaymentsHelper paymentsHelper,
                                    ICombosHelper combosHelper,
                                    IUserHelper userHelper,
                                    IConverterHelper converterHelper)
        {
            _context = context;
            _paymentsHelper = paymentsHelper;
            _combosHelper = combosHelper;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _paymentsHelper.GetPaymentsAsync(this.User.Identity.Name));

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentEntity = await _context.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentEntity == null)
            {
                return NotFound();
            }

            return View(paymentEntity);
        }

        public async Task<IActionResult> Create()
        {
            UserEntity user = await _userHelper.GetUserAsync(this.User.Identity.Name);


            PaymentViewModel model = new PaymentViewModel
            {
                Date=DateTime.Today,
                Banks = _combosHelper.GetComboBanks(),
                User=user,              
                
                
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentViewModel paymentViewModel)
        {
            if (ModelState.IsValid)
            {
                PaymentEntity paymentEntity = await _converterHelper.ToPaymentEntityAsync(paymentViewModel, this.User.Identity.Name, true);
                _context.Add(paymentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentViewModel);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentEntity = await _context.Payments.FindAsync(id);
            if (paymentEntity == null)
            {
                return NotFound();
            }
            return View(paymentEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentEntity paymentEntity)
        {
            if (id != paymentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentEntityExists(paymentEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paymentEntity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentEntity = await _context.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentEntity == null)
            {
                return NotFound();
            }

            return View(paymentEntity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentEntity = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(paymentEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentEntityExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
