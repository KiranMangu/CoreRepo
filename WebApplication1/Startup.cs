using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using WebApplication1.DBContext;
using WebApplication1.Services;

namespace WebApplication1
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
            services.AddControllers();
            //services.AddMvc().AddXmlSerializerFormatters();

            // Versioning
            services.AddApiVersioning();  // Query String and URL
            // Accept Header => Accept: application/json;v=1.0
            /*
                services.AddApiVersioning(config =>
                {
                    config.ApiVersionReader = new MediaTypeApiVersionReader();
                    // Specify the default API Version as 1.0
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    // If the client hasn't specified the API version in the request, use the default API version number 
                    config.AssumeDefaultVersionWhenUnspecified = true;
                });
            */

            // Swagger;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });


            // Dependency Injection
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStudentService, StudentService>();

            // EntityFramework Core
            services.AddDbContext<StudentDbContext>(option => option.UseSqlServer(@"Data Source=DESKTOP-KQSFT2N\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StudentDbContext studentDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            studentDbContext.Database.EnsureCreated();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
