using System.ComponentModel.DataAnnotations;

namespace EntryShop.Models.ViewModelsProjection
{
    public class ClientData
    {
        [Display(Name = "Client ID")]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }
        public ICollection<Order> Orders { get; set; }

        [Display(Name = "Orders")]
        public int OrderQnt
        {
            get
            {
                return Orders.Count;
            }
        }

        [Display(Name = "Average Order Sum")]
        public decimal AvgOrderSum
        {
            get
            {
                if (OrderQnt > 0)
                {
                    decimal totalSum = 0;
                    foreach (var o in Orders)
                    {
                        totalSum += o.TotalPrice;
                    }
                    return totalSum / OrderQnt;
                } else
                {
                    return 0;
                }
                
            }
        }
    }
}
