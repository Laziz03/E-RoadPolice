using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models;
using ERoadPolice.Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ITokenService _tokenService;
        private readonly PoliceRoadDbContext _dbContext;
        private readonly int _refreshTokenLifetime;
        

        public IdentityService(ITokenService tokenService, PoliceRoadDbContext dbContext, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _dbContext = dbContext;

            _refreshTokenLifetime = int.Parse(configuration["JWT:RefreshTokenLigeTimeInMinutes"]);

        }

        public Task<Response<bool>> DeleteDriverAsync(int DriverId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsValidRefreshToken(string refreshToken, int driverId)
        {
            RefreshToken? refreshTokenEntity;
            var res = _dbContext.RefreshTokens.Where(x => x.DriverIds.Equals(driverId) &&
                                                     x.RefreshTokenValue.Equals(refreshToken));


            if (res.Count() != 1)
                return false;


            refreshTokenEntity=res.First();
            if (refreshTokenEntity.ExpireTime < DateTime.Now)
                return false;

            return true;


        }

        public async Task<Response<Token>> LoginAsync(Credential credential)
        {
            credential.Password=_tokenService.ComputeSHA256Hash(credential.Password);
            Driver driver = _dbContext.Drivers.FirstOrDefault(x=> x.Username.Equals( credential.Username)&&
                                                               x.Password.Equals(credential.Password));
            if (driver == null)
                return new("User not fount");

            Token driverToken = await _tokenService.GenerateTokenAsync(driver);

            bool isSucces = await SaveRefreshToken(driverToken.RefreshToken, driver);
            return isSucces ? new(driverToken) : new("Failed save refresh Token");
        }

        public async Task<Response<bool>> Logout()
        {
            return new(true);
        }

        public Task<Response<bool>> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Token>> RefreshToken(Token token)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Token>> RefreshTokenAsync(Token token)
        {
            Driver driver = await _tokenService.GetClaimsFromExpiredTokenAsync(token.AccessToken);
            if (!await IsValidRefreshToken(token.RefreshToken, driver.DriverId))
                return new("Refresh Token Invalid!");
            Token newToken = await _tokenService.GenerateTokenAsync(driver);
            bool isSuccess = await SaveRefreshToken(newToken.RefreshToken, driver);
            return isSuccess ? new(newToken) : new("Failed");

        }

        public async Task<Response<(Driver,Token)>> RegisterAsync(Driver driver)
        {
            driver.Password=_tokenService.ComputeSHA256Hash(driver.Password);
           await _dbContext.Drivers.AddAsync(driver);
           int effectedRows= await _dbContext.SaveChangesAsync(); 
             if (effectedRows <= 0)
            {
                return new("Operation failed");
            }
            Token token = await _tokenService.GenerateTokenAsync(driver);
         bool isSuccess = await SaveRefreshToken(token.RefreshToken,driver);
            return isSuccess ? new((driver, token)) : new("Failed");
        }
        public async Task<bool> SaveRefreshToken(string refreshToken,Driver driver)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return false;

            RefreshToken? refreshTokenEntity;
            var res = _dbContext.RefreshTokens.Where(x => x.DriverIds.Equals(driver.DriverId) &&
                                                     x.RefreshTokenValue.Equals(refreshToken));


            if (res.Count() == 0)
            {
                refreshTokenEntity = new()
                {
                    ExpireTime = DateTime.Now.AddMinutes(_refreshTokenLifetime),
                    DriverIds = driver.DriverId,
                    RefreshTokenValue = refreshToken,
                };
                await _dbContext.RefreshTokens.AddAsync(refreshTokenEntity);
            }

            else if (res.Count() == 1)
            {
                refreshTokenEntity=res.First(); 
                refreshTokenEntity.RefreshTokenValue = refreshToken;
                refreshTokenEntity.ExpireTime = DateTime.Now.AddMinutes(_refreshTokenLifetime);

                _dbContext.RefreshTokens.Update(refreshTokenEntity);   
            }
            else return false;  

                int rows= await _dbContext.SaveChangesAsync();
            return rows > 0;    
        }
    }
}
