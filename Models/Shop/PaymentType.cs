using System.ComponentModel.DataAnnotations;

namespace SuperAdmin.Models.Shop
{
    public class PaymentType
    {
        [Key]    
        
        public int PayTypeID { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
