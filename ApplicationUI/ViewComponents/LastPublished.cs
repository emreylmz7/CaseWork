using ApplicationUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApplicationUI.ViewComponents
{
    public class LastPublished : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LastPublished(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5189/api/Application/GetLastPublished");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<JobDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}