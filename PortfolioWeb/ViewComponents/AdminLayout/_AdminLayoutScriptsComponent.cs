using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptsComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
