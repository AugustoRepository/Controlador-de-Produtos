﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiDDD.Presentation.Authorization
{
    public class JwtAuthorization
    {
        JwtSettings jwtSettings;

        public JwtAuthorization(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public string GenarateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            
            var tokenDeion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token =  tokenHandler.CreateToken(tokenDeion);
            return tokenHandler.WriteToken(token);
        }
    }
}
