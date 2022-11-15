using CvSite.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    [Authorize]
    public class AboutSliderController : Controller
    {
        public string base_uri = "https://localhost:7154/api/AboutSliderPresentation/ListAboutSlider";
        public string GetById = "https://localhost:7154/api/AboutSlider/GetById/";
        public string GetByIdDelete = "https://localhost:7154/api/AboutSlider/GetByIdDelete/";
        public string Edit = "https://localhost:7154/api/AboutSlider/AboutSliderUpdate/";
        public string Add = "https://localhost:7154/api/AboutSlider/AboutSliderAdd/";

        public async Task<IActionResult> AboutSliderInfo()
        {
            using (var httpclient = new HttpClient())
            {
                var responseMessage = await httpclient.GetAsync(base_uri);
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<AboutSlider>>(jsonString);
                return View(value);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AboutSliderEdit(int Id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(GetById + Id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<AboutSlider>(jsonData);
                    return View(values);
                }
                return RedirectToAction(nameof(AboutSliderInfo));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AboutSliderEdit(AboutSlider aboutSlider)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(aboutSlider);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(Edit, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(AboutSliderInfo));
                }
                return View(aboutSlider);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AboutSliderAdd()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AboutSliderAdd(AboutSlider aboutSlider)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(aboutSlider);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(Add, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(AboutSliderInfo));
                }
                return View(aboutSlider);
            }
        }

        public async Task<IActionResult> AboutSliderDelete(int id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.DeleteAsync(GetByIdDelete + id);
                return RedirectToAction(nameof(AboutSliderInfo));
            }
        }
    }
}
