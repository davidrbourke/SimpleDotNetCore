using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Simple.Infrastructure;

namespace Simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.RegisterIoCServices();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                builder => 
                {
                    builder.Run(async context => 
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            Console.WriteLine(error.Error.Message);
                            await context.Response.WriteAsync("{ \"Error\": " + error.Error.Message + "})")
                            .ConfigureAwait(false);
                        }
                    });
                }
            );

            app.Use(async (ctx, next) => {
                Console.WriteLine("Request: {0}", ctx.Request.Path);
                await next();
                Console.WriteLine("Response: {0}, {1}", ctx.Response.StatusCode, ctx.Response.ContentType);
            });
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute("default", "api/{controller}");
            });
        }
    }
}