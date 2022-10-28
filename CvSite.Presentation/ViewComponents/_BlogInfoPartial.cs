using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.Presentation.ViewComponents
{
    public class _BlogInfoPartial : ViewComponent
    {

        public string base_uri = "https://localhost:7154/";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync($"{base_uri}" + "api/BlogInfoPresentation/BlogInfo");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<IEnumerable<BlogInfo>>(jsonString);
            return View(value);
        }
    }
}
