using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EJumping.Core.Middlewares
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;
        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            //await context.Response.WriteAsync("<div>This is from custom Middleware</div>");
            if(!context.User.Identity.IsAuthenticated)
            {
                //throw new Exception("noooo");
                //Console.WriteLine("Heyyyyyyyyy");
                //await context.Response.WriteAsync("<div>user has not logged in yet</div>");
            }
            //await context.Response.WriteAsync("<div>Okayyy</div>");
            //context.Response.Redirect("/Home/Index");
            //context.Response.Redirect("/Home/Index");
            await this._next(context);
        }
    }
}
