using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    public class PortfolioController : Controller
    {
        public string base_uri = "https://localhost:7154/api/PortfolioPresentation/PortfolioList";
        public string GetById = "https://localhost:7154/api/Portfolio/GetById/";
        public string GetByIdDelete = "https://localhost:7154/api/Portfolio/GetByIdDelete/";
        public string Edit = "https://localhost:7154/api/Portfolio/PortfolioUpdate/";
        public string Add = "https://localhost:7154/api/Portfolio/PortfolioAdd/";

        public async Task<IActionResult> PortfolioInfo()
        {
            using (var httpclient = new HttpClient())
            {
                var responseMessage = await httpclient.GetAsync(base_uri);
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<Portfolio>>(jsonString);
                return View(value);
            }
        }

        [HttpGet]
        public async Task<IActionResult> PortfolioEdit(int Id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(GetById + Id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<Portfolio>(jsonData);
                    return View(values);
                }
                return RedirectToAction(nameof(PortfolioInfo));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PortfolioEdit(Portfolio portfolio)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(portfolio);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(Edit, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(PortfolioInfo));
                }
                return View(portfolio);
            }
        }


        [HttpGet]
        public async Task<IActionResult> PortfolioAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PortfolioAdd(Portfolio portfolio)
        {
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(portfolio);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(Add, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(PortfolioInfo));
                }
                return View(portfolio);
            }
        }

        public async Task<IActionResult> PortfolioDelete(int id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.DeleteAsync(GetByIdDelete + id);
                return RedirectToAction(nameof(PortfolioInfo));
            }
        }
    }
}
