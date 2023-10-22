
using ApplicationAPI.Data.Abstract;
using ApplicationAPI.DTO;
using ApplicationAPI.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAPI.Data.Concrete.EfCore
{
    public class EfJobPositionRepository : IJobPositionRepository
    {
        private ApplicationContext _context;
        public EfJobPositionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<JobPosition> JobPositions => _context.JobPositions;

        public void CreateJobPosition(JobPosition jobPosition)
        {
            _context.JobPositions.Add(jobPosition);
            _context.SaveChanges();
        }

        public void DeleteJobPositions(JobPosition jobPosition)
        {
            _context.JobPositions.Remove(jobPosition);
            _context.SaveChanges();
        }

        public void EditJobPosition(JobPosition jobPosition)
        {
            var entity = _context.JobPositions.FirstOrDefault(i => i.JobPositionId == jobPosition.JobPositionId);
            if (entity != null)
            {
                entity.Title = jobPosition.Title;
                entity.Description = jobPosition.Description;
                
                _context.SaveChanges();
            }
        }


    }
}