using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.Presentation.Controllers
{
    public class BlogDetailController : Controller
    {
        public string GetById = "https://localhost:7154/api/BlogDetail/GetById/";
        public async Task<IActionResult> Index(int id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(GetById + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<BlogInfo>(jsonData);
                    return View(values);
                }
                return View();
            }
        }
    }
}