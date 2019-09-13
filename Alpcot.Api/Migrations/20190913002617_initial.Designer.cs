﻿// <auto-generated />
using System;
using Alpcot.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alpcot.Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190913002617_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alpcot.Api.Models.BuyOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePlaced");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("BuyOrders");
                });

            modelBuilder.Entity("Alpcot.Api.Models.SellOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePlaced");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("SellOrders");
                });

            modelBuilder.Entity("Alpcot.Api.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuyOrderId");

                    b.Property<DateTime>("ExecutedDate");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int?>("SellOrderId");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("BuyOrderId");

                    b.HasIndex("SellOrderId");

                    b.HasIndex("StockId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("DataLayer.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Barclays"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vattenfall"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Skania"
                        });
                });

            modelBuilder.Entity("Alpcot.Api.Models.BuyOrder", b =>
                {
                    b.HasOne("DataLayer.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alpcot.Api.Models.SellOrder", b =>
                {
                    b.HasOne("DataLayer.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alpcot.Api.Models.Trade", b =>
                {
                    b.HasOne("Alpcot.Api.Models.BuyOrder", "BuyOrder")
                        .WithMany()
                        .HasForeignKey("BuyOrderId");

                    b.HasOne("Alpcot.Api.Models.SellOrder", "SellOrder")
                        .WithMany()
                        .HasForeignKey("SellOrderId");

                    b.HasOne("DataLayer.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
