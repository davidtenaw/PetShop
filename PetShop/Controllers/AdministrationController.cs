using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdministrationController : Controller
    {

        private Service _service;
        private readonly FileService _fileService;
        private readonly IWebHostEnvironment _host ;
        
        public AdministrationController(Service service, FileService fileService, IWebHostEnvironment host)
        {
            _service = service;
            _fileService = fileService;
            _host = host;
        }



        

        [HttpGet]
        public async Task<IActionResult> NewAnimalView()
        {
            ViewBag.categories = await _service.CategoryRepo.GetAllAsync();
            var categories = await _service.CategoryRepo.GetAllAsync();
            ViewBag.CategoriesList = new SelectList(categories, "Id", "Title");

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> NewAnimalView(Animal animal, IFormFile FileUpload)
        {

            if (ModelState.IsValid)
            {
                // _flieService.SaveFile(FileUpload);
                string ext = Path.GetExtension(FileUpload.FileName);
                //if(ext == ".jpg" || ext == ".gif")
                //{
                animal.ImageName = FileUpload.FileName;
                var saveFile = Path.Combine(_host.WebRootPath, "Images", FileUpload.FileName);
                var stream = new FileStream(saveFile, FileMode.Create);
                await FileUpload.CopyToAsync(stream);
                stream.Close();
                //}

                
                _service?.AnimalRepo.AddAsync(animal);

                return RedirectToAction("SuccessView", "Administration");
            }

            return RedirectToAction("NewAnimalView");
        }


        

        [HttpGet]
        public IActionResult EditAnimalView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditAnimalView(Animal animal)
        {
            if (ModelState.IsValid)
            {
                await _service.AnimalRepo.EditAsync(animal);
                return RedirectToAction("SuccessView");
            }

            return RedirectToAction("EditAnimalView");
        }



        public IActionResult SuccessView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            await _service.CommentReop.AddAsync(comment);


            return RedirectToAction("AnimalDetailsView", "Animals", new { id = comment.AnimalId });
        }



    }
}
