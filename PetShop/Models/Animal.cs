using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PetShop.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name")]
        //[AllLettersValidation(ErrorMessage = "Only letters")]
        public string? Name { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
        //public List<Category>? Categories { get; set; }
      

        [Required(ErrorMessage = "Please enter a name")]
        public string? Description { get; set;}
        public int? PhotoId { get; set; }
        // root/images/dog.png
        public string? ImageName { get; set; }
        // dog.png   cat.jpeg
        [NotMapped]
        public IFormFile? FileUpload { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; } 

        

     

    }

    
}
