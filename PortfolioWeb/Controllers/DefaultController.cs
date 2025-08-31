using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
