using ApplicationAPI.DTO;
using ApplicationAPI.Entity;

namespace ApplicationAPI.Data.Abstract
{
    public interface IJobApplicationRepository
    {
        IQueryable<JobApplication> JobApplications {get;}
        void CreateJobApplication(JobApplication jobApplication);
        void EditJobApplication(ApplicationDTO applicationDTO);
        void DeleteJobApplication(int id);
        JobApplication GetJobApplicationById(int id);

    }
}