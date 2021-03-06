﻿using System.ComponentModel.DataAnnotations;

namespace EFCustomMigrationOperations.Sample.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string SKU { get; set; }

        public decimal Price { get; set; }

        public bool InStock { get; set; }
    }
}
