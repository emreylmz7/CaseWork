using ApplicationAPI.Entity;

namespace ApplicationAPI.Data.Abstract
{
    public interface IJobPositionRepository
    {
        IQueryable<JobPosition> JobPositions {get;}
        void CreateJobPosition(JobPosition jobPosition);
        void EditJobPosition(JobPosition jobPosition);
        void DeleteJobPositions(JobPosition jobPosition);
        
    }
}