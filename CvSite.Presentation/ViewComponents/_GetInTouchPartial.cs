using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.Presentation.ViewComponents
{
    public class _GetInTouchPartial : ViewComponent
    {
        public string base_uri = "https://localhost:7154/";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync($"{base_uri}" + "api/GetInTouchPresentation/OneTouch");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetInTouch>(jsonString);
            return View(value);
        }
    }
}
