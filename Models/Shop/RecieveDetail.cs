﻿
using System.ComponentModel.DataAnnotations;

namespace SuperAdmin.Models.Shop
{
    public class RecieveDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }


        [Required]
        public int? RecieveId { get; set; }

        public Recieve? Recieve { get; set; }
    }
}
