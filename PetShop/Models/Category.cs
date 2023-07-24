using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int? PhotoId { get; set; }
        public virtual ICollection<Animal>? Animals { get; }
    }
}
