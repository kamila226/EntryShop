using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace EntryShop.Models
{
    public enum Status
    {
        Created, Paid, Delivered
    }
    public class Order
    {
        [Display(Name = "Order ID")]
        public int ID { get; set; }

        [Required]
        public int ClientID { get; set; }
        public Client? Client { get; set; }

        [Required]
        public int ProductID { get; set; }
        public Product? Product { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int Quantity { get; set; }

        [Display(Name="Price Total")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice
        {
            get
            {
                if (Product == null || Quantity == 0)
                {
                    return 0;
                }

                return Quantity * Product.Price;
            }
        }

        [Required]
        public Status Status { get; set; }
    }
}
