
using ApplicationAPI.Data.Abstract;
using ApplicationAPI.DTO;
using ApplicationAPI.Entity;

namespace ApplicationAPI.Data.Concrete.EfCore
{
    public class EfJobApplicationRepository : IJobApplicationRepository
    {
        private ApplicationContext _context;
        public EfJobApplicationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<JobApplication> JobApplications => _context.JobApplications;

        public void CreateJobApplication(JobApplication jobApplication)
        {
            _context.JobApplications.Add(jobApplication);
            _context.SaveChanges();
        }

        public void DeleteJobApplication(int id)
        {        
            var jobApplicationToDelete = _context.JobApplications.Find(id);

            if (jobApplicationToDelete != null)
            {
                _context.JobApplications.Remove(jobApplicationToDelete);
                _context.SaveChanges();
            }   
        }

        public void EditJobApplication(ApplicationDTO applicationDTO)
        {
            var entity = _context.JobApplications.FirstOrDefault(i => i.JobApplicationId == applicationDTO.JobApplicationId);
            if (entity != null)
            {
                entity.FirstName = applicationDTO.FirstName;
                entity.LastName = applicationDTO.LastName;
                entity.Email = applicationDTO.Email;
                entity.PhoneNumber = applicationDTO.PhoneNumber;
                entity.Resume = applicationDTO.Resume;
                
                _context.SaveChanges();
            }
        }

        public JobApplication GetJobApplicationById(int id)
        {
            return _context.JobApplications.FirstOrDefault(j => j.JobApplicationId == id);
        }

    }
}