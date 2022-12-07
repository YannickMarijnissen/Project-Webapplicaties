using Project.Data;
using Project.Models;
using Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

    }
}
