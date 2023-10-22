using System.ComponentModel.DataAnnotations;

namespace ApplicationAPI.DTO
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10,ErrorMessage = "max char. limit 10"),MinLength(6,ErrorMessage ="min.char limit 6")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}