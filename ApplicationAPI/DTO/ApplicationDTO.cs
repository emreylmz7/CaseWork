using ApplicationAPI.Entity;

namespace ApplicationAPI.DTO
{
    public class ApplicationDTO
    {
        public int JobApplicationId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Resume { get; set; }
        public int JobPositionId { get; set; }
        public int  UserId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}