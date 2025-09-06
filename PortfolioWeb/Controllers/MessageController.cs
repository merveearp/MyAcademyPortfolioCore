using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Context;
using PortfolioWeb.Entities;

namespace PortfolioWeb.Controllers
{
    public class MessageController (PortfolioContext context): Controller
    {
        public IActionResult Index()
        {
            
            var messages = context.UserMessages.ToList();
            return View(messages);
            
        }

        [HttpGet]
        public async Task<IActionResult> Read(int id)
        {
            var message = await context.UserMessages.FindAsync(id);           
            return View(message);
        }

        [HttpPost]
    
        public async Task<IActionResult> Read(UserMessage form)
        {
            var entity = await context.UserMessages.FindAsync(form.UserMessageId);           
          
            entity.IsRead =! entity.IsRead;
            await context.SaveChangesAsync();
           
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var msg = await context.UserMessages.FindAsync(id);
            context.UserMessages.Remove(msg);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
