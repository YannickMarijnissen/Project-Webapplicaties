using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
