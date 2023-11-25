
using ERoadPolice.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

namespace E_RoadPolice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimeSpanBehavior", true);

           


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructureServices (builder.Configuration);

            builder.Services.AddAutoMapper(typeof(Program).Assembly);






            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = false,
                        ValidateAudience = false
                        
                    };
                }
              );

            /*   builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                     opt => {
                         opt.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                             .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                             ValidateIssuer = false,
                             ValidateAudience = false
                         };
                     }
                   );*/


            /*
              var myOptions = new MyRateLimitOptions();
              builder.Configuration.GetSection(MyRateLimitOptions.MyRateLimit).Bind(myOptions);

              builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter("fixed", options =>
              {
                  options.PermitLimit = 3;
                  options.Window = TimeSpan.FromSeconds(20);
                  //options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                  //options.QueueLimit = 2;
              }));



              builder.Services.AddRateLimiter(_ => _
          .AddTokenBucketLimiter(policyName: "token", options =>
          {
              options.TokenLimit = 4;
              options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
              options.QueueLimit = 3;
              options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
              options.TokensPerPeriod = 3;
          }));


              builder.Services.AddRateLimiter(_ => _
          .AddSlidingWindowLimiter(policyName: "sliding", options =>
          {
              options.PermitLimit = myOptions.PermitLimit;
              options.Window = TimeSpan.FromSeconds(myOptions.Window);
              options.SegmentsPerWindow = myOptions.SegmentsPerWindow;
              options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
              options.QueueLimit = myOptions.QueueLimit;
          }));


              builder.Services.AddRateLimiter(_ => _
          .AddConcurrencyLimiter(policyName: "concurrency", options =>
          {
              options.PermitLimit = myOptions.PermitLimit;

              options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
              options.QueueLimit = myOptions.QueueLimit;
          }));
  */


            var app = builder.Build();


         

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


        /*    app.UseCors(policy =>
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

            app.UseHttpsRedirection();

            //https://referbruv.com/blog/building-custom-responses-for-unauthorized-requests-in-aspnet-core/
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
                {
                    await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
                }
            });*/

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRateLimiter();

        


            app.MapControllers();

            app.Run();
        }
    }
}