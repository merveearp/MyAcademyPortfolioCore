using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class SkillController(PortfolioContext context): Controller
    {
        public IActionResult Index()
        {
            var skills = context.Skills.ToList();
            return View(skills);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {      
            return View();
        }

        public IActionResult CreateSkill(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult DeleteSkill(int id)
        {
            var skill = context.Skills.Find(id);
            context.Skills.Remove(skill);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = context.Skills.Find(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            context.Skills.Update(skill);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
