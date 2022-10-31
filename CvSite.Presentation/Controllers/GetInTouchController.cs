using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    public class GetInTouchController : Controller
    {
        public string base_uri = "https://localhost:7154/api/GetInTouchPresentation/OneTouch";
        public string GetById = "https://localhost:7154/api/GetInTouch/GetById/";
        public string Edit = "https://localhost:7154/api/GetInTouch/GetInTouchUpdate/";
        public async Task<IActionResult> GetInTouchInfo()
        {
            using (var httpclient = new HttpClient())
            {
                var responseMessage = await httpclient.GetAsync(base_uri);
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetInTouch>(jsonString);
                return View(value);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInTouchEdit(int Id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(GetById + Id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<GetInTouch>(jsonData);
                    return View(values);
                }
                return RedirectToAction(nameof(GetInTouchInfo));
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetInTouchEdit(GetInTouch getInTouch)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(getInTouch);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(Edit, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(GetInTouchInfo));
                }
                return View(getInTouch);
            }
        }
    }
}
