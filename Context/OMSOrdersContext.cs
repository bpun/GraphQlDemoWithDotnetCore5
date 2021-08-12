using GraphDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Context
{
    public class OMSOrdersContext : DbContext
    {
        public string DbPath { get; private set; }
        public OMSOrdersContext(DbContextOptions<OMSOrdersContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}GraphQlDemo.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ////seeding
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    DeliveredStatus = "Pending",
                    OrderedDate = DateTime.Now
                },
                 new Order
                 {
                     Id = 2,
                     DeliveredStatus = "Delivered",
                     DeliveredDate = DateTime.Now.AddDays(-1),
                     OrderedDate = DateTime.Now
                 },
                  new Order
                  {
                      Id = 3,
                      DeliveredStatus = "Pending",
                      OrderedDate = DateTime.Now
                  }
                );
            modelBuilder.Entity<LineItem>().HasData(
                new LineItem
                {
                    Id = 1,
                    Name = "IPhone-X",
                    Quantity = 2,
                    OrderId = 1,
                    Price = 12
                },
                  new LineItem
                  {
                      Id = 2,
                      Name = "Oneplus-7",
                      Quantity = 3,
                      OrderId = 3,
                      Price = 8
                  },
                   new LineItem
                   {
                       Id = 3,
                       Name = "Redmi",
                       Quantity = 5,
                       OrderId = 2,
                       Price = 6
                   }
                );
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = 1,
                    ReceiverName = "Roy",
                    Address = "xyz",
                    ContactNo = "12234444",
                    OrderId = 1
                },
                 new OrderDetail
                 {
                     Id = 2,
                     ReceiverName = "Jonny",
                     Address = "abc",
                     ContactNo = "123422",
                     OrderId = 2
                 },
                  new OrderDetail
                  {
                      Id = 3,
                      ReceiverName = "Pinky",
                      Address = "mno",
                      ContactNo = "17886666",
                      OrderId = 3
                  }
                );

        }
        //entities
        //Order summary, details and Line items
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}
