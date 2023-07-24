using Humanizer;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetShop.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace PetShop.ViewComponents
{
    public class MyViewComponent : ViewComponent
    {
        private readonly Service _service;

        public MyViewComponent(Service service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Example: Retrieving animals from the AnimalRepo
            var animalsQuery = await _service.AnimalRepo.GetAllAsync();
            
            // Example: Retrieving categories from the CategoryRepo
            var categories = await _service.CategoryRepo.GetAllAsync();

            // Example: Retrieving comments from the CommentRepo
            var comments = await _service.CommentReop.GetAllAsync();

            // Perform any necessary data processing or additional logic here

            return View(animalsQuery); // Pass the retrieved data to the view
        }


        //public async Task<IViewComponentResult> InvokeAsync(int parameter1, string parameter2)
        //{
        //    // Perform any necessary data retrieval or processing using the _service instance

        //    // Return the view component result
        //    var data = await _service.SomeMethod(parameter1, parameter2);
        //    return View("MyViewComponent", data);
        //}
    }








}
