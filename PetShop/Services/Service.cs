using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using PetShop.Repository;

namespace PetShop.Services
{
    public class Service
    {
        public Service(IRepository<Animal> animalRepo, IRepository<Category> categoryRepo, IRepository<Comment> commentReop)
        {
            AnimalRepo = animalRepo;
            CategoryRepo = categoryRepo;
            CommentReop = commentReop;
            //UserRepo = userRepo;
            // FileRepo = fileRepo;       , IRepository<IFormFile> fileRepo


        }

        public IRepository<Animal> AnimalRepo { get; }
        public IRepository<Category> CategoryRepo { get;}
        public IRepository<Comment> CommentReop { get; }
        //public IRepository<User> UserRepo { get; }
       // public IRepository<IFormFile> FileRepo { get; }


    }

}
