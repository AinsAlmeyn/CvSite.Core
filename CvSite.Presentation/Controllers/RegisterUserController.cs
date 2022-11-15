using CvSite.Core.Entities;
using CvSite.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using System.Text;

namespace CvSite.Presentation.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private string registerApiAddress = "https://localhost:7154/api/Register/SignUp";

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Email = model.Mail,
                    UserName = model.UserName,
                    NameSurname = model.NameSurname
                };
                using (var client = new HttpClient())
                {
                    SignUpApiModel apiModel = new()
                    {
                        Email = user.Email,
                        Password = model.Password,
                        UserName = user.UserName,
                        NameSurname = user.NameSurname
                    };
                    var jsonData = JsonConvert.SerializeObject(apiModel);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync(registerApiAddress, content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("HomePage", "Home");
                    }
                    return View();
                };   
            }
            return View(model);
        }
    }
}
