using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
