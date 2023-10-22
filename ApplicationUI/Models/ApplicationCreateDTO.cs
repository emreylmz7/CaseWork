using ApplicationUI.Models.Entities;

namespace ApplicationUI.Models
{
    public class ApplicationCreateDTO
    {
        public int JobApplicationId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Resume { get; set; }
        public int JobPositionId { get; set; }  
        
    }
}