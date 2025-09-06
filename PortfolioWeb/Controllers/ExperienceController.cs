using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class ExperienceController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var experiences = context.Experiences.ToList();
            return View(experiences);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            context.Experiences.Add(experience);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = context.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            
            context.Experiences.Update(experience);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = context.Experiences.Find(id);
            context.Experiences.Remove(experience);
            context.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
