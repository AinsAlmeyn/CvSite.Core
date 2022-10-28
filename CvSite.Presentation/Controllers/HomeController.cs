using System.Diagnostics;
using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using CvSite.Presentation.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CvSite.Presentation.Controllers;

public class HomeController : Controller
{
    string base_uri = "https://localhost:7154/";
    [HttpGet]
    public async Task<IActionResult> HomePage()
    {
        return View();
    } 
}