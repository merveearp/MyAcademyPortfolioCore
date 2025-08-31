using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.ViewComponents.AdminLayout
{
    public class _AdminLayoutFooterComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
