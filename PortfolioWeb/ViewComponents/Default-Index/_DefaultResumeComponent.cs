using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultResumeComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var educations = context.Educations.ToList();
            var experiences = context.Experiences.ToList();

            var model = (Educations: educations, Experiences: experiences);

            return View(model);
        }
    }
}
