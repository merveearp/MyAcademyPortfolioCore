using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultStatsComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var stats = context.Stats.ToList();
            return View(stats);
        }
    }
}
