using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApplicationUI.Controllers
{
    public class JobsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public JobsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {   
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5189/api/Application/GetActiveJobs");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<JobDTO>>(jsonData);
                return View(values);
            }
            return View();
        }   

        [HttpGet]
        public async Task<IActionResult> Details(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5189/api/Application/GetJobByUrl/{url}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var job = JsonConvert.DeserializeObject<JobDTO>(jsonData);
                
                return View(job);
            }

            return View(); 

            // var client = _httpClientFactory.CreateClient();
            // var responseMessage = await client.GetAsync("http://localhost:5189/api/Application/GetJobByUrl");

            // if (responseMessage.IsSuccessStatusCode)
            // {
            //     var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //     var value = JsonConvert.DeserializeObject<List<JobDTO>>(jsonData);
            //     return View(value);
            // }
            // return View();
        }     
    }
}