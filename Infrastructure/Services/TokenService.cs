using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.IdentityEntities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));

        }

        public string CreateToken(ApplicationUser appUser)
        {
            var claims = new List<Claim>{
               new Claim(JwtRegisteredClaimNames.Email,appUser.Email),
               new Claim(JwtRegisteredClaimNames.GivenName,appUser.DisplayName)
           };
           var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

           var tokendescriptor = new SecurityTokenDescriptor{
               Subject=new ClaimsIdentity(claims),
               Expires=DateTime.Now.AddDays(7),
               Issuer=_config["Token:Issuer"],
               SigningCredentials=cred
           };
           var tokenhandler =  new JwtSecurityTokenHandler();
           var token = tokenhandler.CreateToken(tokendescriptor);
           return tokenhandler.WriteToken(token);
        }

     
    }
}