using CvSite.Core.Entities;
using CvSite.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private string loginApiAddress = "https://localhost:7154/api/Login/SignIn";
        private readonly SignInManager<AppUser> _signIn;
        public AccountController(SignInManager<AppUser> signIn)
        {
            _signIn = signIn;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signIn.PasswordSignInAsync(user.userName, user.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("AboutSliderInfo", "AboutSlider");
                }
                return View(user);
                //using (var client = new HttpClient())
                //{
                //    var jsonData = JsonConvert.SerializeObject(user);
                //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                //    var responseMessage = await client.PostAsync(loginApiAddress, content);
                //    if (responseMessage.IsSuccessStatusCode)
                //    {
                //        return RedirectToAction("AboutSliderInfo", "AboutSlider");
                //    }
                //    return View();
                //};
            }
            return View(user);
        }
    }
}
