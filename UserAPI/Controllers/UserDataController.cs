using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using UserAPI.Exceptions;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserService service;

        public UserDataController (IUserService _service)
        {
            service = _service;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Registration([FromBody] User user)
        {
            try
            {
                service.Register(user);
                return StatusCode(201, "You asre Sucessfully Registersd. PLaese LogIn");

            }
            catch (UserAE uae)
            {
                return Conflict(uae.Message);
            }
            catch
            {
                return StatusCode(500, "Servar error");

            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Log([FromBody] User user)
        {
            try
            {
                var userId = user.UserId;
                var password = user.Password;
                User user1= service.LogIn(userId,password);

                return Ok(TokenGet(user.UserId));
                //return Ok(user1);
            }
            catch (UserNF unf)
            {
                return NotFound(unf.Message);
            }
            catch
            {
                return StatusCode(500, "Servar error");

            }
        }

        private string TokenGet(string userId)
        {
            var claimsi = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("authserver_secret_to_validate_token"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "aserver",
                audience: "jwtclient",
                claims: claimsi,
                expires:DateTime.UtcNow.AddMinutes(30),
                signingCredentials:creds
                );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return JsonConvert.SerializeObject(response);

        } 
    }
}
