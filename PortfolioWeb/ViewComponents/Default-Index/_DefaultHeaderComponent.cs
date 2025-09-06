using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultHeaderComponent(PortfolioContext context) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var socials = context.SocialMedias.ToList();
            return View(socials);
        }
    }
}
