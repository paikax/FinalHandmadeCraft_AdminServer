﻿using HandMadeCraftAdminServer.DbContext;
using HandMadeCraftAdminServer.Services;
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
                
            return services;
        }
        
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlServerConnectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(sqlServerConnectionString));
            
            return services;
        }
    }
}