using System.ComponentModel.DataAnnotations;
using ApplicationUI.Models.Entities;

namespace ApplicationUI.Models
{
    public class ApplicationCreateDTO
    {
        [Required]
        public int JobApplicationId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Resume { get; set; }
        [Required]
        public int JobPositionId { get; set; }  
        
    }
}