using ERoadPolice.Application.Services;
using ERoadPolice.Domain.Entities;
using ERoadPolice.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace E_RoadPolice.Controllers
{
    //[Microsoft.AspNetCore.Components.Route("api/[controller]/[action]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<Response<(Driver, Token)>>Register(Driver driver)
            =>  await   _identityService.RegisterAsync(driver);
         [HttpPost]
        [AllowAnonymous]
        public async Task<Response< Token>>Login(Credential credentials)
            =>  await   _identityService.LoginAsync(credentials);
        [HttpGet]
        public async Task<Response<bool>>Logout()
        => await _identityService.LogoutAsync();
        [HttpDelete]
        public async Task<Response<bool>> Delete(int DriverId)
            => await _identityService.DeleteDriverAsync(DriverId);

    }
}
