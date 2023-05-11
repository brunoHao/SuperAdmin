using System.ComponentModel.DataAnnotations;

namespace SuperAdmin.Models.Shop
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int Type { get; set; }
        public Nullable<decimal> CreditAmount { get; set; }
        public Nullable<decimal> DebitAmount { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<System.DateTime> PaymentDateTime { get; set; }

        public virtual PaymentType? PaymentType { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
