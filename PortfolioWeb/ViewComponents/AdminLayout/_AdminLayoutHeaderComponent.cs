using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeaderComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
