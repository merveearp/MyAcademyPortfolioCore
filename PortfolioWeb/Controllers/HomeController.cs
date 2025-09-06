using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Models;

namespace PortfolioWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
