using Imventory_API.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Imventory_API.Models.Respons;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Imventory_API.Helpers;
using Microsoft.Extensions.Options;

namespace Imventory_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly Models.DatabaseMappings.inventory_schemaContext _context;
        private readonly ILogger<LoginController> _logger;
        private readonly JwtSetting _setting;

        public LoginController(ILogger<LoginController> logger, Models.DatabaseMappings.inventory_schemaContext context, IOptions<JwtSetting> settings)
        {
            _logger = logger;
            _context=context;
            this._setting = settings.Value;
        }


        [NonAction]
        public TokenResponse Authenticate(int uuid, Claim[] claims)
        {
            TokenResponse tokenResponce = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(_setting.securitykey);
            var tokenHandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                );
            tokenResponce.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenHandler);
            return tokenResponce;
        }

        [NonAction]
        private TokenResponse GenerateToken(Models.DatabaseMappings.U01Ser pUser)
        {
            TokenResponse tokenResponce = new TokenResponse();
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(this._setting.securitykey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,pUser.Uuid.ToString()),
                    }
                ),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey
                ), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenHandler.WriteToken(token);
            tokenResponce.JWTToken = finaltoken;
            return tokenResponce;
        }


        [AllowAnonymous]
        [HttpPost(Name = "login")]
        [SwaggerOperation(Tags = new[] { "Authentication and User Info" })]
        [Consumes("application/json")]
        public IActionResult Authenticate(
        [FromBody] Authenticate auth
        )
        {
            bool flag = false;
            if(auth == null)
            {
                return BadRequest();
            }
            var user=_context.U01Sers.First(x=>x.Email.ToLower() == auth.email.ToLower());
            try
            {

                byte[] saltFromDatabase = Helpers.Helpers.StringToByteArray(user.Salt);
                byte[] storedHashedPassword = Helpers.Helpers.StringToByteArray(user.Password);
                //we can use sha1 and sha256 working both by only changing parameter
                byte[] hashedPasswordAttempt =Helpers.Helpers.HashPassword(auth.password, saltFromDatabase, "sha1");

                if (hashedPasswordAttempt.SequenceEqual(storedHashedPassword))
                {
                    flag = true;
                }
                else
                {
                    var resp = new ForbidResult();
                    return resp;
                }
            }
            catch
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new Models.Respons.Generic<Dictionary<string, string>>
                {
                    success = false,
                    error = "Decryption failed.",
                    data = new Dictionary<string, string>(),
                });
            }

            if (flag)
            {
                Models.DatabaseMappings.U01Ser user_details;
                user_details = new Models.DatabaseMappings.U01Ser
                {
                    username = user.username,
                    Uuid = user.Uuid.ToString(),
                    Email = user.Email,
                };
                var responce = GenerateToken(user!);
                var profie = new Profile()
                {
                    email = user_details.Email,
                    name = user_details.username,
                    uuid = user_details.Uuid.ToString(),
                    token = responce
                };
                user_details.LastLoginTimestamp = DateTime.UtcNow;
                _context.SaveChanges();
                return Ok(profie);
            }
            return Unauthorized();

        }
    }
}