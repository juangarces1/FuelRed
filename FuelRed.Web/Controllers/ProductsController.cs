using FuelRed.Web.Data.Entities;
using FuelRed.Web.Helpers;
using FuelRed.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Controllers
{
    public class ProductsController : Controller
    {
    
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public ProductsController(
            DataContext context,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductEntity productEntity = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if (productViewModel.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(productViewModel.ImageFile, "Products");
                }

                ProductEntity productEntity = _converterHelper.ToProductEntity(productViewModel, path, true);
                _context.Add(productEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Already there is a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }

            return View(productViewModel);
        }
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductEntity productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            ProductViewModel productViewModel = _converterHelper.ToProductViewModel(productEntity);
            return View(productViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = productViewModel.ImagePath;

                if (productViewModel.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(productViewModel.ImageFile, "Stations");
                }

                ProductEntity productEntity = _converterHelper.ToProductEntity(productViewModel, path, false);
                _context.Update(productEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("updating"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists a Product {productEntity.Description}. ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }
            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductEntity productEntity = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }       

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
