using CvSite.API.Models;
using CvSite.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.IdentityControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterPreModel model)
        {
            AppUser user = new()
            {
                Email = model.Email,
                NameSurname = model.NameSurname,
                UserName = model.UserName
            };
            string password = model.Password;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                return Ok(result);
            else
            {
                return BadRequest(result);
            }
        }
    }
}