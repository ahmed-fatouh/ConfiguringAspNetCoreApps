using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringAspNetCoreApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;

        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await nextDelegate.Invoke(context);

            switch (context.Response.StatusCode)
            {
                case (403):
                    await context.Response
                        .WriteAsync("Edge browsers aren't allowed to access.");
                    break;
                case (404):
                    await context.Response
                        .WriteAsync("Can't find the requested resource.");
                    break;
                default:
                    break;
            }
        }
    }
}
