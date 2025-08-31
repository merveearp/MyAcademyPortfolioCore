using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;


namespace PortfolioWeb.Controllers
{
    public class ProjectController(PortfolioContext context) : Controller
    {
        private void CategoryDropDown()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories
                                  .Select (x=> new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();
            //YADA 
            //ViewBag.categories =(from  x in categories
            //                    select new SelectListItem
            //                    {
            //                        Text = x.CategoryName,
            //                        Value = x.CategoryId.ToString()
            //                    }).ToList() ;

        }
        public IActionResult Index()
        {
            //Eager loading
            var projects = context.Projects.Include(x =>x.Category).ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            CategoryDropDown();                    
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            CategoryDropDown();

            if (!ModelState.IsValid)
            {
                return View(project);
            }

            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProject( int id)
        {
            CategoryDropDown();
            var project = context.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project model)
        {
            CategoryDropDown();
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            context.Projects.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public IActionResult DeleteProject(int id)
        {
            var project = context.Projects.Find(id);
            context.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
