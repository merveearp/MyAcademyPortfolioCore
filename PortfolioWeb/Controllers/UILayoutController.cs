using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
