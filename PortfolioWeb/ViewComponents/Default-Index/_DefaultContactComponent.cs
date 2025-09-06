using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultContactComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contacts = context.ContactInfos.ToList();
            return View(contacts);
        }
    }
}
