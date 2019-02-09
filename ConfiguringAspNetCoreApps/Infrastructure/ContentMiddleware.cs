using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringAspNetCoreApps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UpTimeService upTime;

        public ContentMiddleware(RequestDelegate next, UpTimeService up)
        {
            nextDelegate = next;
            upTime = up;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().ToLower() == "/middleware")
            {
                await context.Response.WriteAsync(
                        $"This is from the content middleware. App is running for {upTime.Uptime}ms",
                        Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }
}
