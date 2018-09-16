using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static IdentityModel.OidcConstants;

namespace ClientCredSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();
            services
                .AddAuthentication(options => {
                    //options.DefaultAuthenticateScheme = "Bearer";
                    options.DefaultScheme = "acookies";
                    options.DefaultChallengeScheme = "aaa";
                })
                //.AddIdentityServerAuthentication("Bearer", options =>
                // {
                //     options.Authority = "http://localhost:2409";
                //     options.RequireHttpsMetadata = false;
                //     options.ApiName = "api1";
                // })
                 .AddOpenIdConnect("aaa",options => {
                    options.SignInScheme = "acookies";
                    options.Authority = "http://localhost:2409";
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "mvc";
                    options.ClientSecret = "pwd";
                    options.ResponseType = ResponseTypes.CodeIdToken;
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("api1");
                    options.Scope.Add("offline_access");
                 })
                 .AddCookie("acookies",options=> {});                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
