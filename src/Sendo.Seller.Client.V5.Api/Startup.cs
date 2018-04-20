using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog.Web;
using Sendo.Seller.Client.V5.Api.Constants.Configuration;
using Sendo.Seller.Client.V5.Api.Infrastructure;
using Sendo.Seller.Client.V5.Api.Infrastructure.Middleware;

namespace Sendo.Seller.Client.V5.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            #region Jwt Authentication

            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration[JwtConfiguration.Issuer],
                    ValidAudience = Configuration[JwtConfiguration.Issuer],
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration[JwtConfiguration.Key]))
                    };
                });

            #endregion Jwt Authentication

            services.AddAutoMapper (Assembly.GetAssembly (typeof (AutoMapperProfile))); //If you have other mapping profiles defined, that profiles will be loaded too.

            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.WithOrigins (Configuration["pwadomain"]) //.AllowAnyOrigin()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ()
                    .Build ());
            });
            services.AddMvc ().AddJsonOptions (options => {
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;//DateTimeZoneHandling.Utc;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                //app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute ("/error/{0}");

            app.UseExceptionHandler ("/error/500");

            app.UseMiddleware<ErrorWrappingMiddleware> ();

            app.UseAuthentication ();

            app.UseCors ("CorsPolicy");

            app.AddNLogWeb ();
            env.ConfigureNLog ("nlog.config");

            app.UseMvc ();

            //app.UseCors(corsPolicyBuilder =>
            //   corsPolicyBuilder.WithOrigins("http://localhost:8080")
            //  .AllowAnyMethod()
            //  .AllowAnyHeader()
            //);

        }
    }
}