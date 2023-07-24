using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json.Linq;
using PetShop.Models;
using PetShop.Services;
using PetShop.ViewComponents;

namespace PetShop.Controllers
{
    
    public class AnimalsController : Controller
    {
        private Service _service;
        private FileService _fileService;
        private readonly IWebHostEnvironment _host;
        
        
        public AnimalsController(Service service, FileService flieService, IWebHostEnvironment host)
        {
            _service = service;
            _fileService = flieService; 
            _host = host;

            
        }
        
        [HttpGet]

        public async Task<IActionResult> AnimalView()
        {
            ViewBag.categories = await _service.CategoryRepo.GetAllAsync();
			var animals = await _service.AnimalRepo.GetAllAsync();

			var topTwoAnimals = animals
				.OrderByDescending(x => x.Comments?.Count ?? 0) // Assuming Comments is a collection (e.g., List<Comment>) within the Animal class.
				.Take(2)
				.ToList();

			return View(topTwoAnimals);
        }

       
        public async Task<IActionResult> AnimalDetailsView(int id)
        {
            ViewBag.categories = await _service.CategoryRepo.GetAllAsync();
            ViewBag.Animal = await _service.AnimalRepo.GetByIdAsync(id);
            if (ViewBag.Animal == null)
            {

                return NotFound(); // Returning 404 (Not Found)
            }
            return View(ViewBag.Animal.Comments);
        }




        public async Task<IActionResult> CategoriesView(int id)
        {
            ViewBag.Categories = await _service.CategoryRepo.GetAllAsync();
            var category = await _service.CategoryRepo.GetByIdAsync(id);
            var animals = category.Animals;
            return View(animals);
        }



        [HttpPost]

        public async Task<IActionResult> SaveCommentEdit(Comment comment)
        {
            await _service.CommentReop.EditAsync(comment);

            return RedirectToAction("AnimalDetailsView", "Animals", new { id = comment.AnimalId });
        }

        public async Task<IActionResult> Comments(int id, bool delet)
        {
            Comment? comment = await _service.CommentReop.GetByIdAsync(id);
            if (!delet)
            {
                if (comment != null)
                {
                    comment.Edit = true;
                    await _service.CommentReop.SaveAsync();
                }
                id = comment.AnimalId;
                return RedirectToAction("AnimalDetailsView", "Animals", new { id });
            }
            id = comment.AnimalId;
            await _service.CommentReop.DeleteAsync(comment);
            return RedirectToAction("AnimalDetailsView", "Animals", new { id });
        }

        public async Task<IActionResult> CancelCommentEdit(int id)
        {
            Comment? comment = await _service.CommentReop.GetByIdAsync(id);
            if (comment != null)
            {
                comment.Edit = false;
                await _service.CommentReop.SaveAsync();
            }
            return RedirectToAction("AnimalDetailsView", "Animals", new { id = comment.AnimalId });

        }

        

        
        [HttpPost]
        public async Task<IActionResult> SaveComment(Comment comment)
        {
            // Assuming _service is an instance of the service class that interacts with the database

            // Retrieve the associated animal from the database based on the AnimalId
            Animal animal = await _service.AnimalRepo.GetByIdAsync(comment.AnimalId);

            if (animal == null)
            {
                // Handle the case where the animal does not exist
                return NotFound();
            }

            // Associate the animal with the comment
            comment.Animal = animal;

            // Add the comment to the CommentRepo
            await _service.CommentReop.AddAsync(comment);

            return RedirectToAction("AnimalDetailsView", "Animals", new { id = comment.AnimalId });
        }

       


    }
}
