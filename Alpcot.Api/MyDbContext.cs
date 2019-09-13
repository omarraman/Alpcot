using Alpcot.Api.Models;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

//
namespace Alpcot.Api
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, Name = "Barclays" }
                , new Stock { Id = 2, Name = "Vattenfall" }
                , new Stock { Id = 3, Name = "Skania" }
            );

        }
    }
}
