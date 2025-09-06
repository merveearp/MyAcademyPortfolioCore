using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Context;
using PortfolioWeb.Models;
using System.Net;
using System.Security.Claims;

namespace PortfolioWeb.Controllers
{
    [AllowAnonymous]
    public class AuthController(PortfolioContext context) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //Fast fail yöntemi hataları yakala hata yoksa yoluna devam et 
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if (user is null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("fullName",string.Join(" ",user.FirstName,user.LastName))
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
                );
            HttpContext.Session.SetString("UserName", user.UserName);

            return RedirectToAction("Index", "Statistics");

        }
        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.Remove("UserName");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var me = await context.Users.FindAsync(id);
            if (me == null) return NotFound();

            var vm = new ProfileEditViewModel
            {
                UserName = me.UserName,
                FirstName = me.FirstName,
                LastName = me.LastName
            };
            return View(vm);
        }


        [HttpPost]

        public async Task<IActionResult> EditProfile(ProfileEditViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var me = await context.Users.FindAsync(id);
            if (me == null) return NotFound();

            // Kullanıcı adı değişiyorsa benzersiz kontrolü
            if (!string.Equals(me.UserName, vm.UserName, StringComparison.OrdinalIgnoreCase))
            {
                var exists = await context.Users.AnyAsync(u => u.UserName == vm.UserName);
                if (exists)
                {
                    ModelState.AddModelError(nameof(vm.UserName), "Bu kullanıcı adı zaten kullanılıyor.");
                    return View(vm);
                }
                me.UserName = vm.UserName;

                // Name claim ve (kullanıyorsan) Session güncelle
                var identity = (ClaimsIdentity)User.Identity!;
                var nameClaim = identity.FindFirst(ClaimTypes.Name);
                if (nameClaim != null) identity.RemoveClaim(nameClaim);
                identity.AddClaim(new Claim(ClaimTypes.Name, me.UserName));
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity)
                );
                HttpContext.Session.SetString("UserName", me.UserName);
            }

            me.FirstName = vm.FirstName.Trim();
            me.LastName = vm.LastName.Trim();           
            await context.SaveChangesAsync();
            TempData["ok"] = "Profil güncellendi.";
            return RedirectToAction("EditProfile");
        }
    
        [HttpGet]
        public IActionResult EditPassword()
        {
            return View(new EditPasswordViewModel());
        }

        // POST: /Auth/EditPassword

        [HttpPost]

        public async Task<IActionResult> EditPassword(EditPasswordViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            // 1) Giriş yapan kullanıcıyı al (önce Id claim'i, yoksa UserName fallback)
            var idStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            PortfolioWeb.Entities.User? me = null;

            if (!string.IsNullOrEmpty(idStr) && int.TryParse(idStr, out var id))
                me = await context.Users.FindAsync(id);
            else if (!string.IsNullOrEmpty(User.Identity?.Name))
                me = await context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity!.Name);

            if (me == null) return RedirectToAction(nameof(Login));

            // 2) Mevcut şifre doğru mu?
            if (!string.Equals(me.Password, vm.CurrentPassword))
            {
                ModelState.AddModelError(nameof(vm.CurrentPassword), "Mevcut şifre hatalı.");
                return View(vm);
            }

            // 3) Yeni şifre eskiyle aynı olmasın
            if (vm.CurrentPassword == vm.NewPassword)
            {
                ModelState.AddModelError(nameof(vm.NewPassword), "Yeni şifre mevcut şifreyle aynı olamaz.");
                return View(vm);
            }

            // 4) Güncelle (NOT: Üretimde hash kullanmalısın — BCrypt/Argon2)
            me.Password = vm.NewPassword; // TODO: Hashle
            await context.SaveChangesAsync();

            TempData["ok"] = "Şifreniz başarıyla güncellendi.";
            return RedirectToAction(nameof(EditPassword));
            
        }
    }
}

