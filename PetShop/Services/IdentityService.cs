using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PetShop.Services
{
    public class IdentityService
    {
      public  SignInManager<IdentityUser> SignInManager { get; }
      public  UserManager<IdentityUser> UserManager { get; }
      public  RoleManager<IdentityRole> RoleManager { get; }

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        

    }

    
}
