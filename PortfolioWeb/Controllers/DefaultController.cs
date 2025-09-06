using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    [AllowAnonymous]
    public class DefaultController (PortfolioContext context): Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(UserMessage message)
        {
            context.UserMessages.Add(message);
            context.SaveChanges();
            await Task.Delay(1000);
            return RedirectToAction("Index");
        }
    }
}
