using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core_Meeting_16.Services;

namespace Core_Meeting_16
{
    public class Startup
    {
        IServiceCollection _services;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<TimeService>();
            services.AddTransient<MessageService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageService sender, TimeService timeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Map("/time", GetTime);
            app.Run(async context => {
                context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
                await context.Response.WriteAsync(sender.SendMessage());
            });

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         StringBuilder builder = new StringBuilder();
            //         builder.AppendLine("<table><thead><tr>");
            //         builder.AppendLine("<th></th><th></th><th></th></tr></thead><tbody>");
            //         foreach (var service in _services) {
            //             builder.AppendLine("<tr>");
            //             builder.AppendLine($"<td>{service.ServiceType.FullName}</td>");
            //             builder.AppendLine($"<td>{service.Lifetime}</td>");
            //             builder.AppendLine($"<td>{service.ImplementationType?.FullName}</td>");
            //             builder.AppendLine($"</tr>");
            //         }
            //         builder.AppendLine("</tbody></table>");
            //         await context.Response.WriteAsync(builder.ToString());
            //     });
            // });
        }

        public static void GetTime(IApplicationBuilder app)
        {
            TimeService timeService = app.ApplicationServices.GetService<TimeService>();
            app.Run(async context => await context.Response.WriteAsync($"Curr time: {timeService.Time}"));
        }
    }
}
