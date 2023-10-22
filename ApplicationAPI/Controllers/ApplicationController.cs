using System.Text.Json;
using System.Text.Json.Serialization;
using ApplicationAPI.Data.Abstract;
using ApplicationAPI.DTO;
using ApplicationAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApplicationController : ControllerBase
    {
        
        private IJobPositionRepository _jobPositionRepository;
        public ApplicationController(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobPositionRepository.JobPositions.Select(p => JobToDTO(p)).ToListAsync();

            return Ok(jobs);
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveJobs()
        {
            var jobs = await _jobPositionRepository.JobPositions.Where(p=> p.IsActive).Select(p => JobToDTO(p)).ToListAsync();

            return Ok(jobs);
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> GetJobByUrl(string url)
        {
            var job = await _jobPositionRepository.JobPositions.FirstOrDefaultAsync(p=> p.Url == url);
            return Ok(job);
        }

        [HttpGet]
        public async Task<IActionResult> GetLastPublished()
        {
            // return View( await
            //     _postRepository
            //     .Posts
            //     .Where(i => i.IsActive)
            //     .OrderByDescending(p => p.PublishedOn)
            //     .Take(5)
            //     .ToListAsync()   
            // );
            var jobs = await _jobPositionRepository.JobPositions.Where(p=> p.IsActive).OrderByDescending(p => p.PostedDate).Take(5).ToListAsync();  

            return Ok(jobs);
        }
        



        private static JobDTO JobToDTO(JobPosition job)
        {
            return new JobDTO
            {
                JobPositionId = job.JobPositionId,
                Title = job.Title,
                Description = job.Description,
                Content = job.Content,
                Url = job.Url,
                Image = job.Image
            };
        }
        
    }
}