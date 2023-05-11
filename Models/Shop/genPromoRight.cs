using System.ComponentModel.DataAnnotations;

namespace SuperAdmin.Models.Shop
{
    public class genPromoRight
    {
        [Key]
        public int PromoRightID { get; set; }
        public string? ImageURL { get; set; }
        public string? AltText { get; set; }
        public string? OfferTag { get; set; }
        public string? Title { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    }
}
