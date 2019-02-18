using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.ServiceInterfaces;
using DomainModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ITNews.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        public IUserService userService;
        public AuthorizeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("registration")]
        public async Task Registration(UserInfo user)
        {
            user.Roles = new List<RoleInfo> { new RoleInfo { Id = 1 } };
            userService.Create(user);
            await Token(user);
        }

        [HttpPost("token")]
        public async Task Token(UserInfo user)
        {
            UserInfo dbUser;
            var identity = GetIdentity(user.Email, user.Password, out dbUser);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            dbUser.Password = null;
            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(new { token = response, user = dbUser }, Formatting.Indented,
                 new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
        }

        private ClaimsIdentity GetIdentity(string username, string password, out UserInfo user)
        {
            user = userService.GetUser(username, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(AuthOptions.DefaultEmailClaimType, user.Email),
                    new Claim(AuthOptions.DefaultIdClaimType, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Roles.First().Name)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", AuthOptions.DefaultEmailClaimType,
                    AuthOptions.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetActions()
        {
            var actionsObject = new
            {
                getToken = Url.Action("Token", "Authorize", null , this.Request.Scheme, this.Request.Host.Value),
                registration = Url.Action("Registration", "Authorize", null, this.Request.Scheme, this.Request.Host.Value)
            };
            return Json(new { actions = actionsObject });
        }
    }
}