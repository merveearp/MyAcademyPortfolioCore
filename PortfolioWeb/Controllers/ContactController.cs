using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class ContactController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var contact = context.ContactInfos.FirstOrDefault();
            return View(contact);
        }


        [HttpGet]
        public IActionResult EditContact()
        {
            var contact = context.ContactInfos.FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            context.ContactInfos.Update(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
