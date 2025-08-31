using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponent :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
