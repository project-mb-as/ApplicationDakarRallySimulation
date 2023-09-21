﻿using Contracts;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace DakarRally.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }


        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config) 
        { 
            var connectionString = config["ConnectionStrings:Local"]; 
            services.AddDbContext<RepositoryContext>(o => o.UseSqlite(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services) 
        { 
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>(); 
        }
    }
}
