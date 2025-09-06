using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class SocialMediaController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var medias = context.SocialMedias.ToList();
            return View(medias);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        public IActionResult CreateSocialMedia(SocialMedia media)
        {
            context.SocialMedias.Add(media);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult DeleteSocialMedia(int id)
        {
            var media = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(media);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var media = context.SocialMedias.Find(id);
            return View(media);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia media)
        {
            context.SocialMedias.Update(media);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
