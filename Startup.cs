using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using projetoRafael.Data;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace projetoRafael
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
             
            services.AddDbContext<Contexto>(opt=>opt.UseMySql(Configuration.GetConnectionString("MySqlConnectionString")));
            services.AddScoped<Contexto,Contexto>();
            services.AddControllers();
        // .AddNewtonsoftJson(options =>
        //      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        // );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo{Title="Documentação Api", Version="v1"});

                var xmlFile= $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath= Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath,includeControllerXmlComments:true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c=>
            {
                c.RoutePrefix= string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
            });
        }
    }
}
