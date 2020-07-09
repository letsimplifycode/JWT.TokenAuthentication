using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWT.TokenAuthentication.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        public TokenController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpGet, AllowAnonymous]
        public string CreateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
            new Claim("user", "John Doe"),
            new Claim("email", "John.Doe@email.com")
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds,
                claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
