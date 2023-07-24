using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using System.Diagnostics.Metrics;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PetShop.Data
{
    public class ShopContext : DbContext
    { 
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Title = "Mammals",
                },
                new Category
                {
                    Id = 2,
                    Title = "Birds",
                }
                
            );
           ;

            

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    Id = 1,
                    Name = "Pitbull",
                    CategoryId = 1,
                    PhotoId = 1,
                    ImageName = "dog.jpg",
                    Description = "The American Pit Bull Terrier is a dog breed recognized\n by the United Kennel Club and the American Dog Breeders Association,\n but not the American Kennel Club",
                },
                new Animal
                {
                    Id = 2,
                    Name = "Lion",
                    CategoryId = 1,
                    PhotoId = 1,
                    ImageName = "dog.jpg",
                    Description = "The lion is a species in the family Felidae it is a muscular, deep-chested cat with a short,\n rounded head, a reduced neck, and round ears, and a hairy tuft at the end of its tail.",
                },
                new Animal
                {
                    Id = 3,
                    Name = "Elephant",
                    CategoryId = 1, 
                    PhotoId = 1,
                    ImageName = "dog.jpg",
                    Description = "Elephants are large mammals of the family Elephantidae and the order Proboscidea.\n Three species are currently recognized:\n the African bush elephant, the African forest elephant, and the Asian elephant.",
                },

                new Animal
                {
                    Id = 4,
                    Name = "Eagle",
                    PhotoId = 1,
                    CategoryId = 2,
                    ImageName = "dog.jpg",
                    Description = "Eagles are large birds of prey belonging to the family Accipitridae. They are known for their powerful build, keen eyesight, and soaring flight. Eagles are found on every continent.",
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Description = "Amazing animal",
                    //LastEdited = DateTime.Now,
                    AnimalId = 1,
                },
                new Comment
                {
                    Id = 2,
                    Description = "Beautiful creature",
                    //LastEdited = DateTime.Now,
                    AnimalId = 1,
                },
                new Comment
                {
                    Id = 3,
                    Description = "Impressive species",
                    //LastEdited = DateTime.Now,
                    AnimalId = 2,
                });

        }


       
    }

}
