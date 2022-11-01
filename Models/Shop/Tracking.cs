using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperAdmin.Models.Shop
{
    public class Tracking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Status { get; set; }

        [Required]
        public int? RecieveId { get; set; }

        public Recieve? Recieve { get; set; }
    }
}
