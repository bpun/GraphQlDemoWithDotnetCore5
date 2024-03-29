﻿// <auto-generated />
using System;
using GraphDemo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphDemo.Migrations
{
    [DbContext(typeof(OMSOrdersContext))]
    [Migration("20210812161019_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("GraphDemo.Models.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("LineItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IPhone-X",
                            OrderId = 1,
                            Price = 12m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "Oneplus-7",
                            OrderId = 3,
                            Price = 8m,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 3,
                            Name = "Redmi",
                            OrderId = 2,
                            Price = 6m,
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("GraphDemo.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeliveredDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeliveredStatus")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 0,
                            DeliveredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveredStatus = "Pending",
                            OrderedDate = new DateTime(2021, 8, 12, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(569)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 0,
                            DeliveredDate = new DateTime(2021, 8, 11, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(3692),
                            DeliveredStatus = "Delivered",
                            OrderedDate = new DateTime(2021, 8, 12, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(4427)
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 0,
                            DeliveredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveredStatus = "Pending",
                            OrderedDate = new DateTime(2021, 8, 12, 21, 55, 19, 349, DateTimeKind.Local).AddTicks(4442)
                        });
                });

            modelBuilder.Entity("GraphDemo.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReceiverName")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "xyz",
                            ContactNo = "12234444",
                            OrderId = 1,
                            ReceiverName = "Roy"
                        },
                        new
                        {
                            Id = 2,
                            Address = "abc",
                            ContactNo = "123422",
                            OrderId = 2,
                            ReceiverName = "Jonny"
                        },
                        new
                        {
                            Id = 3,
                            Address = "mno",
                            ContactNo = "17886666",
                            OrderId = 3,
                            ReceiverName = "Pinky"
                        });
                });

            modelBuilder.Entity("GraphDemo.Models.LineItem", b =>
                {
                    b.HasOne("GraphDemo.Models.Order", "Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GraphDemo.Models.OrderDetail", b =>
                {
                    b.HasOne("GraphDemo.Models.Order", "Order")
                        .WithOne("OrderDetail")
                        .HasForeignKey("GraphDemo.Models.OrderDetail", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GraphDemo.Models.Order", b =>
                {
                    b.Navigation("LineItems");

                    b.Navigation("OrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
