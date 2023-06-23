using BookApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace BookApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add configuration provider for accessing appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Retrieve the connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure the database context with the connection string
            services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(connectionString));

            // Add other services as needed

            services.AddControllers();
        }

    }
}
