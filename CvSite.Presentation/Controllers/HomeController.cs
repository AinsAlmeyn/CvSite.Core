using System.Diagnostics;
using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using CvSite.Presentation.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CvSite.Presentation.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    
    public async Task<IActionResult> HomePage()
    {
        return View();
    }

    public string Add = "https://localhost:7154/api/Messasge/MessageAdd/";

    [HttpPost]
    public async Task<IActionResult> MessageAdd(Message message)
    {
        using (var client = new HttpClient())
        {
            var jsonData = JsonConvert.SerializeObject(message);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(Add, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(HomePage));
            }
            return RedirectToAction(nameof(HomePage));
        }
    }
}