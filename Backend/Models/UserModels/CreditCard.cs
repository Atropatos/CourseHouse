using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;

namespace CourseHouse.Models
{
    [Table("CreditCards")]
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard(ErrorMessage = "Incorrect credit card number.")]
        public string CreditCardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration date of the card is required.")]
        [Display(Name = "Expiration date.")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Incorrect CVV code.")]
        public string Cvv { get; set; }

        [Required(ErrorMessage = "The name of the holder is required")]
        [Display(Name = "Name of the holder.")]
        public string HolderName { get; set; } = string.Empty;
    }
}
