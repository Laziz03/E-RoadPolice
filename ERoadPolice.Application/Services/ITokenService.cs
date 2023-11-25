using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Application.Services
{
    public interface ITokenService
    {
        Task<Token> GenerateTokenAsync(Driver driver);
        Task<Driver> GetClaimsFromExpiredTokenAsync(string accessToken);
        Task<string> GenerateRefreshTokenAsync();
        Task<Token> GetNewTokenFromExpiredTokenAsync(Token tokens);
        string ComputeSHA256Hash(string input);
    }
}
