using System.Security.Claims;
using System.Text;
using ApplicationUI.Models;
using ApplicationUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ApplicationUI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ApplicationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5189/api/Application/GetActiveJobs");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<JobDTO>>(jsonData);
            List<SelectListItem>  jobvalues = (from x in values!.ToList()select new SelectListItem{
                Text = x.Title,
                Value = x.JobPositionId.ToString()
            }).ToList();

            ViewBag.v = jobvalues;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationCreateDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var application = ApplicationToDTO(model);
            application.UserId = int.Parse(userId ?? "");

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(application);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5189/api/Job/Create",stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5189/api/Job/List");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<JobApplication>>(jsonData);

            if (string.IsNullOrEmpty(role))
            {
                values = values!.Where(i => i.UserId == userId).ToList(); 
            }

            return View(values);
        }
        
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5189/api/Job/Delete/{id}");
            
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5189/api/Application/GetApplication/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApplicationDTO>(jsonData);
                return View(values);
            }   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ApplicationDTO model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:5189/api/Application/Update",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }  
            return View();
        }



            








        private static ApplicationDTO ApplicationToDTO(ApplicationCreateDTO application)
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
                UserId = 1,
                ApplicationDate = DateTime.Now,
                Status = Models.ApplicationStatus.InReview
            };
        }
    }
}