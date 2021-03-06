﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringAspNetCoreApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items["EdgeBrowser"] as bool? == true)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }
}
