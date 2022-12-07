using Project.Data;
using Project.Models;
using Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProjectContext _context;

        public AdminController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Products()
        {
            ProductenOverviewViewModel vm = new ProductenOverviewViewModel()
            {
                Producten = _context.Products.ToList()
            };

            return View(vm);
        }

        public IActionResult ProductDetails(int id)
        {
            Product product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                ProductDetailsViewModel vm = new ProductDetailsViewModel()
                {
                    ProductId = product.ProductId,
                    Naam = product.Naam,
                    InVoorraad = product.InVoorraad,
                    Type = product.Type,
                    Afbeelding = product.Afbeelding,
                    Beschrijving = product.Beschrijving,
                    Rating = product.Rating,
                    CategorieId = product.CategorieId,
                    Prijs = product.Prijs,
                };

                return View(vm);
            }
            else
            {
                ProductenOverviewViewModel vm = new ProductenOverviewViewModel()
                {
                    Producten = _context.Products.ToList()
                };
                return View("Index", vm);
            }
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Product()
                {
                    
                    Naam = viewModel.Naam,
                    InVoorraad = viewModel.InVoorraad,
                    Type = viewModel.Type,
                    Afbeelding = viewModel.Afbeelding,
                    Beschrijving = viewModel.Beschrijving,
                    Rating = viewModel.Rating,
                    CategorieId = viewModel.CategorieId,
                    Prijs = viewModel.Prijs,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
                return NotFound();

            Product product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();

            if (product == null)
                return NotFound();

            EditProductViewModel vm = new EditProductViewModel()
            {
                ProductId = product.ProductId,
                Naam = product.Naam,
                InVoorraad = product.InVoorraad,
                Type = product.Type,
                Afbeelding = product.Afbeelding,
                Beschrijving = product.Beschrijving,
                Rating = product.Rating,
                CategorieId = product.CategorieId,
                Prijs = product.Prijs,
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, EditProductViewModel viewModel)
        {
            if (id != viewModel.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new Product()
                    {
                        ProductId = viewModel.ProductId,
                        Naam = viewModel.Naam,
                        InVoorraad = viewModel.InVoorraad,
                        Type = viewModel.Type,
                        Afbeelding = viewModel.Afbeelding,
                        Beschrijving = viewModel.Beschrijving,
                        Rating = viewModel.Rating,
                        CategorieId = viewModel.CategorieId,
                        Prijs = viewModel.Prijs,
                    };
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Products.Any(p => p.ProductId == viewModel.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Products));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                DeleteProductViewModel vm = new DeleteProductViewModel()
                {
                    ProductId = product.ProductId,
                    Naam = product.Naam,
                    InVoorraad = product.InVoorraad,
                    Type = product.Type,
                    Afbeelding = product.Afbeelding,
                    Beschrijving = product.Beschrijving,
                    Rating = product.Rating,
                    CategorieId = product.CategorieId,
                    Prijs = product.Prijs,
                };

                return View(vm);
            }
            else
            {
                ProductenOverviewViewModel vm = new ProductenOverviewViewModel()
                {
                    Producten = _context.Products.ToList()
                };
                return View("Index", vm);
            }
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirm(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Products));
        }

        public IActionResult Winkels()
        {
            return View();
        }

        public IActionResult Gebruikers()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }
    }
}
