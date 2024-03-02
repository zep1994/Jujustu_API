using Jujustu_API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.IdentityModel.Tokens;
using System.Text;
using Jujustu_API.Models;
using Microsoft.IdentityModel.Tokens;

namespace Jujustu_API
{
    public class Startup
    {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

                services.AddControllers();

                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //    .AddJwtBearer(options =>
                //    {
                //        options.TokenValidationParameters = new TokenValidationParameters
                //        {
                //            ValidateIssuer = true,
                //            ValidateAudience = true,
                //            ValidateLifetime = true,
                //            ValidateIssuerSigningKey = true,
                //            ValidIssuer = Configuration["Jwt:Issuer"],
                //            ValidAudience = Configuration["Jwt:Audience"],
                //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                //        };
                //    });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthentication();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }