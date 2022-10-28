using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperAdmin.Models.Shop
{

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(225)]
        [Required]
        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Count { get; set; }

        public string? Desc { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
