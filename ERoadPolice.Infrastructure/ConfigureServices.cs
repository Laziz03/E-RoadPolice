using ERoadPolice.Application.Services;
using ERoadPolice.Infrastructure.DataAccess;
using ERoadPolice.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERoadPolice.Infrastructure
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
        
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IOfficerService, OfficerService>();
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentityService, IdentityService>();    
            services.AddDbContext<PoliceRoadDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbConnection")));
        }
    }
}