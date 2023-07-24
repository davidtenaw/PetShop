using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IdentityService identityService;
  
        public AccountController(IdentityService identityService)
        {
            this.identityService = identityService;
        }

      

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser() { UserName = user.UserName };

                var result = await identityService.UserManager.CreateAsync(identityUser, user.Password!);

                if (result.Succeeded)
                {

                    var ans = await identityService.SignInManager.PasswordSignInAsync(user.UserName
                        !, user.Password!, false, false);
                    if (ans.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewBag.ErrorM = result.Errors;
            }
            return RedirectToAction("Index", "Home"); 
        }

       

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginModel user)
        {
            if (ModelState.IsValid)
            {

                var ans = await identityService.SignInManager.PasswordSignInAsync(user.UserName
                        !, user.Password!, false, false);
                if (ans.Succeeded)
                {
                    var userforDb = identityService.UserManager.FindByNameAsync(user.UserName!).Result;
                    if (userforDb != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            
            }
            return RedirectToAction("Index", "Home");
            //return View(nameof(LogIn)); 
        }


        [HttpGet]
        public IActionResult LogOut()
        {
            identityService.SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

      

    }

}
