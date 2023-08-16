using System.ComponentModel.DataAnnotations;

namespace EntryShop.Models.ViewModelsProjection
{
    public class OrderData
    {
        [Display(Name = "Order ID")]
        public int ID { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Price Total")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        public Status Status { get; set; }
        public Client? Client { get; set; }
        public Product? Product { get; set; }
    }
}
