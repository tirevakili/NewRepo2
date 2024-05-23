using GhorfeDarWeb.Core.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayaTejaratDto.Options.API;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TakGhahCore.DTOs.UserModel;
using TakGhahQeb.Models;
using TakGhahWeb.Services.Authentication;

namespace TakGhahQeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient = new();
        private TakGhahWeb.Services.Implements.IAuthenticationService authenticationService = new TakGhahWeb.Services.Authentication.AuthenticationService();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            //var res = await _httpClient.PostAsync($"{APIs.BaseUrl}{APIs.Authentication}", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));

            var token = await authenticationService.SignIn(login);
            if (token != null && token != "")
            {
                string access_token = token!;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler?.ReadToken(access_token!) as JwtSecurityToken;
                var userID = jsonToken!.Claims.FirstOrDefault(u => u.Type == "UserID")!.Value;
                // var Role = jsonToken!.Claims.FirstOrDefault(u => u.Type == "Role")!.Value;

                var claims = new List<Claim>()
                    {

                        new Claim(ClaimTypes.NameIdentifier,userID),
                        new Claim(ClaimTypes.Name,login.Email!.ToString())
                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {

                };
                await HttpContext.SignInAsync(principal, properties);

                return Redirect("/");
                // ViewBag.Login = true;  
            }
            else
            {
                ModelState.AddModelError("Email", "ایمیل نامعتبر هست");
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
