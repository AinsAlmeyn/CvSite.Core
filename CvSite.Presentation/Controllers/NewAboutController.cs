using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    public class NewAboutController : Controller
    {
        public string base_uri = "https://localhost:7154/api/";
        public string GetById = "https://localhost:7154/api/NewAbout/GetById/";
        public string NewAboutUpdate = "https://localhost:7154/api/NewAbout/NewAboutUpdate/";
        public async Task<IActionResult> NewAboutInfo()
        {
            using (var httpclient = new HttpClient())
            {
                var responseMessage = await httpclient.GetAsync($"{base_uri}" + "AboutPresentation/NewAbout");
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<NewAbout>(jsonString);
                return View(value);
            }
        }

        [HttpGet]
        public async Task<IActionResult> NewAboutEdit(int id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(GetById + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<NewAbout>(jsonData);
                    return View(values);
                }
                return RedirectToAction(nameof(NewAboutInfo));
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewAboutEdit(NewAbout newAbout)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(newAbout);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(NewAboutUpdate, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(NewAboutInfo));
                }
                return View(newAbout);
            }
        }
    }
}
