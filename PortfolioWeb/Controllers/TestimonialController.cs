using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;
using PortfolioWeb.Models;

namespace PortfolioWeb.Controllers
{
    public class TestimonialController(PortfolioContext context) : Controller
    {
       
        public IActionResult Index()
        {
            var testimonials = context.Testimonials.ToList();
            return View(testimonials);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial model)
        {
           
                context.Testimonials.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            
        }



        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            return View(testimonial);
        }  
        
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Update(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            context.Remove(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
