using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultAboutComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var abouts=context.Abouts.FirstOrDefault();
            return View(abouts);
        }
    }
}
