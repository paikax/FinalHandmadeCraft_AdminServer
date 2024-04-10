using HandMadeCraftAdminServer.DbContext;
using HandMadeCraftAdminServer.Services;
using HandMadeCraftAdminServer.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace HandMadeCraftAdminServer.ServicesCollection
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthenticationStatus, AuthenticationStatus>();

                
            return services;
        }
        
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlServerConnectionString = configuration.GetConnectionString("DefaultConnection");
            string mongoDBConnectionString = configuration.GetConnectionString("MongoDBConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(sqlServerConnectionString));

            services.AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(mongoDBConnectionString);
            });

            services.AddScoped<IMongoDatabase>(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var databaseName = "handmadecraft"; // Replace with your actual MongoDB database name
                return mongoClient.GetDatabase(databaseName);
            });

            return services;
        }

    }
}