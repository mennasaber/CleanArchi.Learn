using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using CleanArchi.Learn.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CleanArchiDbContext>();
            services.Configure<IdentityOptions>(opts => {
                opts.User.RequireUniqueEmail = true;
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
