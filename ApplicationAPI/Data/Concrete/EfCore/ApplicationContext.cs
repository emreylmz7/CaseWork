using ApplicationAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAPI.Data.Concrete.EfCore
{
    public class ApplicationContext:DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
        public DbSet<JobPosition> JobPositions => Set<JobPosition>();
        public DbSet<User> Users => Set<User>();

    }

}