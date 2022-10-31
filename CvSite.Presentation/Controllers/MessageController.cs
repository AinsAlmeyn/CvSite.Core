using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    public class MessageController : Controller
    {
        public string base_uri = "https://localhost:7154/api/Messasge/ListMessage";
        public string GetByIdDelete = "https://localhost:7154/api/Messasge/GetByIdDelete/";
        public async Task<IActionResult> MessageInfo()
        {
            using (var httpclient = new HttpClient())
            {
                var responseMessage = await httpclient.GetAsync(base_uri);
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<Message>>(jsonString);
                return View(value);
            }
        }

        public async Task<IActionResult> MessageDelete(int id)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.DeleteAsync(GetByIdDelete + id);
                return RedirectToAction(nameof(MessageInfo));
            }
        }
    }
}
