using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperAdmin.Models.Shop
{

    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public string? UnitWeight { get; set; }
        public string? Size { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> UnitInStock { get; set; }
        public Nullable<int> UnitOnOrder { get; set; }
        public Nullable<bool> ProductAvailable { get; set; }
        public string? ImageURL { get; set; }
        public string? AltText { get; set; }
        public Nullable<bool> AddBadge { get; set; }
        public string? OfferTitle { get; set; }
        public string? OfferBadgeClass { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? Picture1 { get; set; }
        public string? Picture2 { get; set; }
        public string? Picture3 { get; set; }
        public string? Picture4 { get; set; }
        public string? Note { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public virtual Suppliers? Supplier { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Wishlist>? Wishlists { get; set; }
    }
}
