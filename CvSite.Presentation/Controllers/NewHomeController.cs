using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    public class NewHomeController : Controller
    {
        public string base_uri = "https://localhost:7154/api/";
        public string GetById = "https://localhost:7154/api/NewHome/GetById/";
        public string Edit = "https://localhost:7154/api/NewHome/NewHomeUpdate/";
        public async Task<IActionResult> NewHomeInfo()
        {
            using (var httpclient = new HttpClient())
            {
                var responseMessage = await httpclient.GetAsync($"{base_uri}" + "HomePresentation/Home");
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Home>(jsonString);
                return View(value);
            }
        }

        [HttpGet]
        public async Task<IActionResult> NewHomeEdit(int Id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(GetById + Id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<Home>(jsonData);
                    return View(values);
                }
                return RedirectToAction(nameof(NewHomeInfo));
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewHomeEdit(Home home)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(home);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(Edit, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(NewHomeInfo));
                }
                return View(home);
            }
        }
    }
}
