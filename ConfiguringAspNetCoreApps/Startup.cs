using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ConfiguringAspNetCoreApps.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ConfiguringAspNetCoreApps
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration config)
        {
            configuration = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UpTimeService>();
            services.AddMvc(opts => opts.RespectBrowserAcceptHeader = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(configuration.GetSection("ShortCircuitMiddleware")
                .GetValue<bool>("EnableBrowserShortCircuit"))
            {
                app.UseMiddleware<BrowserTypeMiddleware>();
                app.UseMiddleware<ShortCircuitMiddleware>();
            }
 
            app.UseExceptionHandler("/Home/Error");
            app.UseStaticFiles();
            app.UseMvc(route =>
                route.MapRoute(name: "default",
                               template: "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
