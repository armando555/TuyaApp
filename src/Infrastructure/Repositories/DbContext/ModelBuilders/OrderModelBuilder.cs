using Domain.Order.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DbContext.ModelBuilders;

public static class OrderModelBuilder
{
    public static void MapOrder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(i =>
        {
            i.Property(o=> o.Id).ValueGeneratedOnAdd();
//            i.Property(o => o.Customer).HasMaxLength(500).IsRequired();
        });
    }
}