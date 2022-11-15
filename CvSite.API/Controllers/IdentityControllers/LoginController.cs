using CvSite.API.Models;
using CvSite.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.API.Controllers.IdentityControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signIn;
        public LoginController(SignInManager<AppUser> signIn)
        {
            _signIn = signIn;
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(LoginPreModel loginModel)
        {
            var result = await _signIn.PasswordSignInAsync(loginModel.userName, loginModel.password, false, true);
            if (result.Succeeded)
                return Ok(result);
            else
                return Ok(result);
        }
    }
}
