using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
