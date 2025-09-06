using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class EducationController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var educations = context.Educations.ToList();
            return View(educations);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            context.Educations.Add(education);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEducation(int id)
        {
            var education = context.Educations.Find(id);
            context.Educations.Remove(education);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var education = context.Educations.Find(id);
            return View(education);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {

            context.Educations.Update(education);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
