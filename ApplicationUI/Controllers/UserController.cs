using System.Security.Claims;
using System.Text;
using ApplicationUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApplicationUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }




        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5189/api/UsersApi/Login",stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var isUser = JsonConvert.DeserializeObject<UserLoginModel>(data);

                var userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser!.UserId.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Name ?? ""));
                userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? "avatar.jpg"));

                if (isUser.Email == "emreyilmaz@gmail.com")
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                }

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties {
                    IsPersistent = true
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );
                
                return RedirectToAction("Index","Home");
            }

            
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }     


        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5189/api/UsersApi/Register",stringContent);

            if (ModelState.IsValid)
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("","Email or username is in use, please re-enter");
                }
                return RedirectToAction("Login"); 
            }
            return View(model);
        }


        // public IActionResult Profile(string username)
        // {
        //     if (string.IsNullOrEmpty(username))
        //     {   
        //         return NotFound();
        //     }
        //     var user = _userRepository
        //                     .Users
        //                     .Include(i => i.Posts)
        //                     .Include(i => i.Comments)
        //                     .ThenInclude(i => i.Post)
        //                     .FirstOrDefault(i => i.UserName == username);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(user);
        // }
       
    }
}