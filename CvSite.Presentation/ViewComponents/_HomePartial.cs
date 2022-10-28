using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.Presentation.ViewComponents
{
    public class _HomePartial : ViewComponent
    {
        public string base_uri = "https://localhost:7154/";

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync($"{base_uri}" + "api/HomePresentation/Home");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<Home>(jsonString);
            return View(value);
        }
    }
}
