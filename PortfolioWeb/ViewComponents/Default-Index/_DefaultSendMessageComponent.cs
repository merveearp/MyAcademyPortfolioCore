using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultSendMessageComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
