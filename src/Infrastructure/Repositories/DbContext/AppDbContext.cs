using Domain.Customer.Entities;
using Domain.Order.Entities;
using Infrastructure.Repositories.DbContext.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories.DbContext;

public class AppDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customer { get;set; }
    public DbSet<Order> Order{ get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.MapCustomer();
        modelBuilder.MapOrder();
    }


}