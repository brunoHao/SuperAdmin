using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperAdmin.Models.Shop
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Picture1 { get; set; }
        public string? Picture2 { get; set; }
        public Nullable<bool> isActive { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
