using System.Diagnostics;
using CvSite.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using CvSite.Presentation.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CvSite.Presentation.Controllers;

public class HomeController : Controller
{

    public async Task<IActionResult> HomePage()
    {
        return View();
    } 
}