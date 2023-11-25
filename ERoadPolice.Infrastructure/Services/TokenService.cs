using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public async Task<string> GenerateRefreshTokenAsync()
        {
            return ComputeSHA256Hash((DateTime.Now.ToString() + "myKey"));

        }

        public string ComputeSHA256Hash(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }

            return builder.ToString();

        }


        public async Task<Token> GenerateTokenAsync(Driver driver)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, driver.FullName),
                new Claim("Id",driver.DriverId.ToString()),

            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            double accessTokenLifetime = double.Parse(_configuration["JWT:AccessTokenLifeTimeInMinutes"]);
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(accessTokenLifetime),
                signingCredentials: credentials,
                claims: claims

                );
            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new()
            {
                AccessToken = accessToken,
                RefreshToken = await GenerateRefreshTokenAsync(),
            };


        }

        public Task<Token> GetNewTokenFromExpiredTokenAsync(Token tokens)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetClaimsFromExpiredTokenAsync(string accessToken)
        {
            

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken);
            var claims = (jsonToken as JwtSecurityToken)?.Claims;
            var driverClaims = claims?.ToArray();
            Driver driver = new()
            {
                DriverId = int.Parse(driverClaims.First(x => x.Type.Equals("Id")).Value),
                //FullName = driverClaims.First(x => x.Type.Equals(ClaimTypes.NameIdentifier).Value)
            };

            return Task.FromResult(driver);






        }

    }
}
