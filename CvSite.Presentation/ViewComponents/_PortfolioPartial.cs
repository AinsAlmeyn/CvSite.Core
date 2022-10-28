using CvSite.Core.Entities;
using CvSite.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.Presentation.ViewComponents
{
    public class _PortfolioPartial : ViewComponent
    {
        public string base_uri = "https://localhost:7154/";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync($"{base_uri}" + "api/PortfolioPresentation/PortfolioList");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<IEnumerable<Portfolio>>(jsonString);
            return View(value);
        }
    }
}
