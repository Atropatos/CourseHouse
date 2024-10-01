using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseHouse.Models;
using Microsoft.AspNetCore.Identity;

namespace CourseHouse.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        /* [Key]
         public int UserId { get; set; }

         [Required(ErrorMessage = "Name is required.")]
         [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
         [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Name can only contain letters.")]
         [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
         public string Name { get; set; } = string.Empty;

         [Required(ErrorMessage = "Last name is required.")]
         [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long.")]
         [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last name can only contain letters.")]
         [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.")]
         public string LastName { get; set; } = string.Empty;

         [EmailAddress(ErrorMessage = "Invalid email address")]
         [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
         public string Email { get; set; } = string.Empty;

         [ForeignKey("Role")]
         [Required(ErrorMessage = "Role is required.")]
         public int RoleId { get; set; }
         public Role Role { get; set; }

         [Required]
         [MinLength(5, ErrorMessage = "Password must be at least 5 characters long!")]
         public string Password { get; set; } = string.Empty;
     }*/
    }
}