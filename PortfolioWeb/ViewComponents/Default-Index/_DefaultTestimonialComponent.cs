using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.ViewComponents.Default_Index
{
    public class _DefaultTestimonialComponent(PortfolioContext context) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var testimonials = context.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
