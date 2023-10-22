namespace ApplicationAPI.Entity
{
    public class User
    { 
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public List<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}