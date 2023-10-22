using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationUI.Models.Entities;

namespace ApplicationUI.Models
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

    public enum ApplicationStatus
    {
        InReview,
        Approved,
        Rejected
    }
}