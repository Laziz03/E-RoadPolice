using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERoadPolice.Application.Services
{
    public interface IIdentityService
    {
        Task<Response<(Driver,Token)>> RegisterAsync(Driver driver);
        Task<Response<Token>> LoginAsync(Credential credential);
        Task<Response<bool>> LogoutAsync();

        Task<Response<Token>> RefreshTokenAsync(Token token);
        Task<Response<bool>> DeleteDriverAsync(int DriverId);

        Task<bool> SaveRefreshToken(string refreshToken,Driver driver);
        Task<bool> IsValidRefreshToken(string refreshToken,int driverId ); 
    }
}
