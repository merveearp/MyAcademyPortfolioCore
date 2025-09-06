using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultSkillComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var skills = context.Skills.ToList();
            return View(skills);
        }
    }
}





