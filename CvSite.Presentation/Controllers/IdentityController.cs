using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace CvSite.Presentation.Controllers
{
    public class IdentityController : Controller
    {
        //private readonly UserManager _userManager;
        

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string data)
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
