using casestudy11.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casestudy11.Data;
using SkillMgnt.Data;

namespace Casestudy11
{
    public class Startup
    {
        readonly string CorsPolicy = "_corsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<ISkillMgntContext, WebApiContext>();


            services.AddControllers();
            services.AddSwaggerGen();

            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.AddDbContext<WebApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebApiContext")));

            //services.AddDbContext<Casestudy11Context>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("Casestudy11Context")));


            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                    builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            //services.AddDbContext<Casestudy11uepContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("Casestudy11uepContext")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            
             app.UseHttpsRedirection();

            app.UseRouting();

           app.UseCors(CorsPolicy);



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
