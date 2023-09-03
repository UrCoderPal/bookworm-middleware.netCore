using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Controllers
{
    public class MyShelfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
