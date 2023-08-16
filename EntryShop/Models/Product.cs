using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace EntryShop.Models
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public int ID { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public string? Title { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
    }
}
