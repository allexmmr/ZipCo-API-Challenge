using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TestProject.Data;
using TestProject.Data.Migrations;
using TestProject.WebAPI.Controllers;
using TestProject.WebAPI.Services;
using TestProject.WebAPI.Services.Interface;
using TestProject.WebAPI.ViewModels;

namespace TestProject.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddControllers();
            services.AddRazorPages();

            services.AddDbContext<ZipCoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MSSQL"));
            });

            // Set up dependency injection for controllers and services
            services.AddScoped<IService<AccountResponse, AccountRequest>, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogger, Logger<AccountController>>();
            services.AddScoped<ILogger, Logger<UserController>>();

            // Dependencies from Repositories project
            RepositoriesDependencies.Register(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Project API", Version = "v1" });

                // Get xml comments path
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ZipCoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(q =>
            {
                q.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Project API v1");
            });

            DbInitialiser.Initialise(context);
        }
    }
}
