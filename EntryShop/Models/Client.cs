using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EntryShop.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class Client
    {
        [Display(Name = "Client ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public string FullName {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
