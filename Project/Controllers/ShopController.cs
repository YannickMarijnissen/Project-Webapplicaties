using Project.Data;
using Project.Models;
using Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProjectContext _context;

        public ShopController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CategorieOverviewViewModel vm = new CategorieOverviewViewModel()
            {
                Categories = _context.Categories.ToList()
            };

            return View(vm);
        }
        public IActionResult Supplementen()
        {
            ProductenOverviewViewModel vm = new ProductenOverviewViewModel()
            {
                Producten = _context.Products.ToList()
            };


            return View(vm);
        }
        public IActionResult Kleding()
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



    }
}
