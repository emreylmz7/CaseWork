using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using ApplicationAPI.DTO;
using Microsoft.AspNetCore.Identity;
using ApplicationAPI.Data.Abstract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ApplicationAPI.Entity;

namespace ApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersApiController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UsersApiController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO model)
        {
            var isUser = await _userRepository.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password== model.Password);
            if (isUser == null)
            {
                return BadRequest();
            }
            return Ok(isUser);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {        
            var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName || x.Email == model.Email );
            if (user == null)
            {
                _userRepository.CreateUser(new User{
                    UserName = model.UserName,
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Image = "avatar.jpg"
                } );
                return Ok("Kayıt Başarılı");
            }
            else
            {
                return BadRequest("Kullanıcı Adı ve Şifre Kullanımda");
            }
        }
    }
}