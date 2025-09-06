using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeaderComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.username = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
