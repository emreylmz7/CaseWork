using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApplicationUI.Models;
using Newtonsoft.Json;

namespace ApplicationUI.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5189/api/Application/GetJobs");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<JobDTO>>(jsonData);
            return View(values);
        }
        return View();
    }

}
