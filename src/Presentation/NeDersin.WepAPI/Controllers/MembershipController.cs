using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.DTOs.Extensions;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.StaticMethods;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembershipController : BaseController
    {
        private readonly IUserService userService;
        public MembershipController(IUserService userService, HateoasEnumeration hateoasEnumeration, ILogger<UserController> logger) : base(hateoasEnumeration.GetUserControllerHateoas, logger)
        {
            this.userService = userService;
        }

        [HttpPost("[action]")]
        public IActionResult Register(AddUserRequestDTO user)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<AddUserRequestDTO>(nameof(Register));
            var result = userService.Add(user);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<AddUserRequestDTO>(nameof(Register));

            IReturnModel<bool> result = userService.CheckPassword(user.Email, user.Password.ToSha256());
            LogResultError(result);
            IActionResult status = StaticHelperMethods.SolveResult(result, hateoasModel);

            if(status is OkObjectResult) //burası benimde hoşuma gitmiyor ama vakit kalmadı
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Email),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok(GenerateJwtToken(claims));
            }
            return status;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Console.WriteLine("Çıkış Yaptı");
            return Ok();
        }

        private string GenerateJwtToken(List<Claim> claims)
        {
            var secretKey = Encoding.UTF8.GetBytes("YourSecretKey12345678");
            var issuer = "client";
            var audience = "server";
            var expires = DateTime.UtcNow.AddMinutes(30);
            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return "Bearer " + tokenHandler.WriteToken(tokenOptions);
        }
    }
}
