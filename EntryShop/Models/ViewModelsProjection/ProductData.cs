using System.ComponentModel.DataAnnotations;

namespace EntryShop.Models.ViewModelsProjection
{
    public class ProductData
    {
        [Display(Name = "Product ID")]
        public int ID { get; set; }
        public int Code { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
