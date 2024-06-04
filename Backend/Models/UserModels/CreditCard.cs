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
        public string CreditCardNumber { get; set; } = "0000 0000 0000 0000";

        [Required]
        [Display(Name = "Expiration date.")]
        [YearMonth(ErrorMessage = "Please enter a valid year and month (YYYY-MM).")]
        public string ExpirationDate { get; set; } = "2025-12";

        [Required(ErrorMessage = "CVV code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Incorrect CVV code.")]
        public string Cvv { get; set; } = "000";

        [Required(ErrorMessage = "The name of the holder is required")]
        [Display(Name = "Name of the holder.")]
        public string HolderName { get; set; } = string.Empty;

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
    }
}
