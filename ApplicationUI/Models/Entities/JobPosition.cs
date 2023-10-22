using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationUI.Models.Entities
{
    public class JobPosition
    {
        public int JobPositionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime PostedDate { get; set; }
        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
        
    }
}