using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class AboutController (PortfolioContext context): Controller
    {
        public IActionResult Index()
        {
            var aboutInfo =context.Abouts.FirstOrDefault();
            return View(aboutInfo);
        }

        
        [HttpGet]
        public IActionResult EditAbout()
        {
            var aboutInfo = context.Abouts.FirstOrDefault();
            return View(aboutInfo);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            context.Abouts.Update(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
