using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Ids4Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ids4Sample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentityServer(options =>
            {
                options.UserInteraction.LoginUrl = "/Login";
                options.UserInteraction.ErrorUrl = "/Error";
            })
                .AddDeveloperSigningCredential()
                .AddClientStore<MyClientStore>()
                .AddResourceStore<MyResourceStore>()
                .AddProfileService<MyProfileService>()
                .AddResourceOwnerValidator<MyResourceOwnerValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}
