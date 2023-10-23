using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApplicationAPI.Data.Abstract;
using ApplicationAPI.DTO;
using ApplicationAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JobController : ControllerBase
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private IJobApplicationRepository _jobApplicationRepository;
        public JobController(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };
        }

        

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationDTO model)
        {
            try
            {
                var mevcutBasvuru = await _jobApplicationRepository.JobApplications
                    .FirstOrDefaultAsync(x => x.UserId == model.UserId && x.JobPositionId == model.JobPositionId);

                if (mevcutBasvuru != null)
                {
                    return BadRequest("Aynı Kullanıcı Kimliği ve İş Pozisyonu Kimliği ile bir iş başvurusu zaten mevcut.");
                }

                var yeniIsBasvurusu = new JobApplication
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Resume = model.Resume,
                    JobPositionId = model.JobPositionId,
                    UserId = model.UserId,
                    ApplicationDate = model.ApplicationDate,
                    Status = model.Status
                };

                _jobApplicationRepository.CreateJobApplication(yeniIsBasvurusu);

                return Ok(yeniIsBasvurusu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"İç Sunucu Hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await _jobApplicationRepository.JobApplications.Include(p => p.JobPosition).ToListAsync();
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);
    
            return Ok(json);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jobApplicationRepository.DeleteJobApplication(id);
            return Ok("Başvuru Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetApplication(int id)
        {
            var application = _jobApplicationRepository.GetJobApplicationById(id);

            if (application == null)
            {
                return BadRequest();
            }

            ApplicationToDTO(application);
            return Ok(application);
        }

        [HttpPut]
        public IActionResult Edit(ApplicationDTO applicationDTO)
        {
            var application = _jobApplicationRepository.JobApplications.FirstOrDefault(a => a.JobApplicationId == applicationDTO.JobApplicationId);
            if (application == null)
            {
                return BadRequest("Başvuru Bulunamadı");
            }
            _jobApplicationRepository.EditJobApplication(applicationDTO);
            return Ok();
        }



        private static ApplicationDTO ApplicationToDTO(JobApplication application)
        {
            return new ApplicationDTO
            {
                JobApplicationId = application.JobApplicationId,
                FirstName = application.FirstName,
                LastName = application.LastName,
                Email = application.Email,
                PhoneNumber = application.PhoneNumber,
                Resume = application.Resume,
                JobPositionId = application.JobPositionId,
                UserId = application.UserId,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status
            };
        }
    }
}





// [HttpPost]
        // public async Task<IActionResult> Create(ApplicationDTO model)
        // {
        //     var jobApplication = await _jobApplicationRepository.JobApplications.FirstOrDefaultAsync(x => x.UserId == model.UserId || x.JobPositionId == model.JobPositionId );
            
        //     if (jobApplication == null)
        //     {
        //         _jobApplicationRepository.CreateJobApplication( new JobApplication{
        //             FirstName = model.FirstName,
        //             LastName = model.LastName,
        //             Email = model.Email,
        //             PhoneNumber = model.PhoneNumber,
        //             Resume = model.Resume,
        //             JobPositionId = model.JobPositionId,
        //             UserId = model.UserId,
        //             ApplicationDate = model.ApplicationDate,
        //             Status = model.Status
        //         }); 
        //         return Ok("Kayıt Başarılı");
        //     }
        //     return BadRequest(model);
        // }