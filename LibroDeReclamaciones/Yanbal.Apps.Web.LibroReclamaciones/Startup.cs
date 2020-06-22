using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;
using Netcore.Infrastructure.Data.Context;
using Netcore.Domain;

using static Netcore.Infrastructure.Crosscutting.Util;
using Netcore.Infrastructure.Crosscutting;

using Netcore.Application.MapperProfiles;
using Netcore.Application.Contracts;
using Template.Netcore.Application.Implementations;
using Netcore.Domain.Agregates.EmpleadoAgg;
using Netcore.Infrastructure.Data.Repositories;

namespace Netcore.Web
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplicationInsightsTelemetry();

            var urlsPermitidas = Configuration.GetSection("UrlsPermitidas").GetSection("Urls").Value.Split("|||"); // services.Configure<UrlsPermitidas>(Configuration.GetSection("UrlsPermitidas")) as UrlsPermitidas;

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(urlsPermitidas);
                                  });
            });

           // services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var result = new BadRequestObjectResult(context.ModelState);

                            // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
                            result.ContentTypes.Add(MediaTypeNames.Application.Json);
                            result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                            return result;
                        };
                    });
            services.Configure<ReCaptchaSettings>(Configuration.GetSection("GoogleReCaptcha"));
            services.Configure<EncryptionAlgorithm>(Configuration.GetSection("EncryptionAlgorithm"));
            // services.Configure<Google>(Configuration.GetSection("Google"));

            services.AddControllers();
            services.AddControllersWithViews();
            ConfigureInjections(services);



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

         

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                // app.UseExceptionHandler("/Pedido/Error");

            }
            else
            {
                //app.UseExceptionHandler("/Error");


                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404 ||
                    context.Response.StatusCode == 401 ||
                    context.Response.StatusCode == 400 ||
                    context.Response.StatusCode == 403 ||
                    context.Response.StatusCode == 500)
                    {
                        // context.Request.Path = "/Home";
                        // await context.Response.WriteAsync(File.ReadAllText(env.WebRootPath + "/index.html"));
                        context.Request.Path = string.Format("/Error/{0}", context.Response.StatusCode);
                        await next();
                    }
                    // await next();
                });
                app.UseHsts();
            }
 

         


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
          

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Edit}/{id}");


                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Error}");

                /*endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Error}/{action=PageNotFound}");*/


            });
           
        }



        private void ConfigureInjections(IServiceCollection services)
        {


            #region Inject dbcontext

            services.AddAutoMapper(typeof(AutoMapperProfile));

            var sqlConnectionString = Configuration.GetConnectionString("AppDbContext");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionString));

            #endregion

            #region Inject App Service

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmpleadoAppService, EmpleadoAppService>();

            #endregion

            #region Inject Repositories

            services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
            /*services.AddTransient<IPedidoRepository, PedidoRepository>();*/

            #endregion

        }
    }
}
