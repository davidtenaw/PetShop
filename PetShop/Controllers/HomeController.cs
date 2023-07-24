using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private Service _service;

        private readonly IdentityService _identityService;
        public HomeController(Service service, IdentityService identityService )
        {
            _service = service; 
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("AnimalView", "Animals");
        }
       

        
       


    }
}
