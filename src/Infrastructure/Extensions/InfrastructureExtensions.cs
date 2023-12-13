using Application.Customer;
using Domain.Customer;
using Domain.Customer.Repositories;
using Application.Order;
using Domain.Order;
using Domain.Order.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Order element services
        services.AddDbContext<AppDbContext>(
            o => o.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddDbContext<AppDbContext>();
        services.AddScoped<ICustomerProcess, CustomerProcess>();
        // Order services
        services.AddDbContext<AppDbContext>(
            o => o.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddDbContext<AppDbContext>();
        services.AddScoped<IOrderProcess, OrderProcess>();
        return services;
    }
}