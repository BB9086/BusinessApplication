using AutoMapper;
using BusinessMobileApi.Data;
using BusinessMobileApi.Dtos;
using BusinessMobileApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BusinessMobileApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jwtsettings;

        public UserController(IUserRepo repository, IMapper mapper, IOptions<JWTSettings> jwtsettings)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtsettings = jwtsettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult IsUserValid([FromBody] Credentials credentials)
        { 
            var user = _repository.IsUserValid(credentials);
            if (user != null) 
            {
                var token = GenerateAccessToken(user.id);

                return Ok(token);
            }
            return BadRequest("User not found");
        }

        private string GenerateAccessToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
