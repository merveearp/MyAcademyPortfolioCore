using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;

namespace PortfolioWeb.Controllers
{
    
    public class StatisticsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.projectCount= context.Projects.Count();
            ViewBag.skillAverage = context.Skills.Average(x => x.Percentage).ToString("00.00");
            ViewBag.unreadMessageCount = context.UserMessages.Count(x =>x.IsRead==false);
            ViewBag.lastMessageOwner = context.UserMessages.OrderByDescending(x =>x.UserMessageId).Select(x =>x.Name).FirstOrDefault();

            var minDate = context.Experiences.Min(x => x.StartYear);

            int years = DateTime.Now.Year - minDate.Year;

            ViewBag.ExperienceYear = years;

            var stats = context.Stats.ToList();
            return View(stats);
        }
    }
}
