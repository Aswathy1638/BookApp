using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BookApp;
using BookApp.Models;
using System.Configuration;

namespace BookApp.Controllers
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Retrieve the connection string from appsettings.json
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Configure the database context with the connection string
            services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
