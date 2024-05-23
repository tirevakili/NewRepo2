using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TakGhahCore.DTOs.UserModel;
using TakGhahCore.Repostiory;
using TakGhahCore.UOF;

namespace TakGhahServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private IUserService _userServices;



        public BaseController(IUserService userServices)
        {

            _userServices = userServices;

        }
        [HttpPost("/Login")]
        public IActionResult Login([FromBody] LoginViewModel Verifay)
        {
            var auth = _userServices.AuthenticationUser(Verifay);
            if (auth != null)
            {
                var scarifyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("43443FDFDF34DF34343fdf344SDFSDFSDFSDFSDF4545354345SDFGDFGDFGDFGdffgfdGDFGDGR%"));
                var singingCredentials = new SigningCredentials(scarifyKey, SecurityAlgorithms.HmacSha256);

                var TokenOption = new JwtSecurityToken(
                    issuer: "https://api.GhorfeDar.com/",
                    audience: "token",
                    claims: new List<Claim>
                    {
                            new Claim("UserID", auth!.UserID.ToString()),
                    },
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: singingCredentials

                    );

                var tokenstring = new JwtSecurityTokenHandler().WriteToken(TokenOption);

                Request?.HttpContext?.Response?.Headers?.Add("Token", tokenstring);



                return Ok(new { token = tokenstring });
            }
            else { return BadRequest("کاربر پیدا نشد"); }

        }
    }
}
