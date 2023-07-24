using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(20)]
        public string? Description { get; set; }
        public bool Edit { get; set; } = false;
        public Animal? Animal { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        //public DateTime? LastEdited { get; set; }





    }
}
