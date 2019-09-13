using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

//
namespace DataLayer
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<BuyOrder> BuyOrder { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Vehicle>().HasData(
            //    new Vehicle()
            //    {
            //        Id = 1,
            //        RegistrationNo = "ABC123",
            //        VehicleId = "YS2R4X20005399401",
            //        Connected = false
            //    },
            //    new Vehicle()
            //    {
            //        Id = 2,
            //        RegistrationNo = "DEF456",
            //        VehicleId = "VLUR4X20009093588",
            //        Connected = true
            //    }, new Vehicle()
            //    {
            //        Id = 3,
            //        RegistrationNo = "GHI789",
            //        VehicleId = "VLUR4X20009048066",
            //        Connected = false
            //    }, new Vehicle()
            //    {
            //        Id = 4,
            //        RegistrationNo = "JKL012",
            //        VehicleId = "YS2R4X20005388011",
            //        Connected = true
            //    }, new Vehicle()
            //    {
            //        Id = 5,
            //        RegistrationNo = "MNO345",
            //        VehicleId = "YS2R4X20005387949",
            //        Connected = false
            //    }, new Vehicle()
            //    {
            //        Id = 6,
            //        RegistrationNo = "PQR678",
            //        VehicleId = "VLUR4X20009048066",
            //        Connected = true
            //    }, new Vehicle()
            //    {
            //        Id = 7,
            //        RegistrationNo = "STU901",
            //        VehicleId = "YS2R4X20005387055",
            //        Connected = false
            //    }
            //);
            //modelBuilder.Entity<Customer>().HasData(

            //    new Customer()
            //    {
            //        Id = 1,
            //        Address = "Cementvägen 8, 111 11 Södertälje",
            //        Name = "Kalles Grustransporter AB"
            //    },
            //    new Customer()
            //    {
            //        Id = 2,
            //        Address = "Balkvägen 12, 222 22 Stockholm",
            //        Name = "Johans Bulk AB"
            //    },
            //    new Customer()
            //    {
            //        Id = 3,
            //        Address = "Budgetvägen 1, 333 33 Uppsala",
            //        Name = "Haralds Värdetransporter AB"
            //    }
            //);

            //modelBuilder.Entity<CustomerVehicle>().HasData(
            //    new CustomerVehicle() { VehicleId = 1, CustomerId = 1 },
            //    new CustomerVehicle() { VehicleId = 2, CustomerId = 1 },
            //    new CustomerVehicle() { VehicleId = 3, CustomerId = 1 },

            //    new CustomerVehicle() { VehicleId = 4, CustomerId = 2 },
            //    new CustomerVehicle() { VehicleId = 5, CustomerId = 2 },


            //    new CustomerVehicle() { VehicleId = 6, CustomerId = 3 },
            //    new CustomerVehicle() { VehicleId = 7, CustomerId = 3 }

            //);

            //modelBuilder.Entity<CustomerVehicle>().HasKey(m => new { m.CustomerId, m.VehicleId });

        }
    }
}
