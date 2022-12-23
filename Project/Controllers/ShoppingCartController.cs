using Project.Data;
using Project.Models;
using Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ProjectContext _context;
        public ShoppingCartController(ProjectContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            ShoppingCartOverviewViewModel vm = new ShoppingCartOverviewViewModel()
            {
                Winkelmand = _context.Cart.ToList()
            };
            return View(vm);
        }
    }
}
