using Domain.Customer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DbContext.ModelBuilders;

public static class CustomerModelBuilder
{
    public static void MapCustomer(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData( new Customer {
            Id = 1,
            Name = "E1",
        });
        modelBuilder.Entity<Customer>().HasData( new Customer {
            Id = 2,
            Name = "E2",
        });
        modelBuilder.Entity<Customer>().HasData( new Customer {
            Id = 3,
            Name = "E3",
        });
        modelBuilder.Entity<Customer>().HasData( new Customer {
            Id = 4,
            Name = "E4",
        });
        modelBuilder.Entity<Customer>().HasData( new Customer {
            Id = 5,
            Name = "E5",
        });
        modelBuilder.Entity<Customer>(i =>
        {
            i.Property(o=> o.Id).ValueGeneratedOnAdd();
            i.Property(o => o.Name).HasMaxLength(60).IsRequired();
        });
    }
}