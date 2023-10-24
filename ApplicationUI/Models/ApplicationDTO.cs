using System.ComponentModel.DataAnnotations;

namespace ApplicationUI.Models
{
    public class ApplicationDTO
    {
        [Required]
        public int JobApplicationId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Resume { get; set; }
        [Required]
        public int JobPositionId { get; set; }
        [Required]
        public int  UserId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }

    }

    public enum ApplicationStatus
    {
        Değerlendiriliyor,
        Onaylandı,
        Reddedildi
    }
}