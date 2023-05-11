using System.ComponentModel.DataAnnotations;

namespace SuperAdmin.Models.Shop
{
    public class Wishlist
    {
        [Key]
        public int WishlistID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> isActive { get; set; }

        public virtual AppUser? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}
