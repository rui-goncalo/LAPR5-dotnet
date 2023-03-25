﻿// <auto-generated />
using DDDSample1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDDNetCore.Migrations
{
    [DbContext(typeof(DDDSample1DbContext))]
    [Migration("20221217151817_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DDDSample1.Domain.Deliveries.Delivery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("DDDSample1.Domain.Orders.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DDDSample1.Domain.Warehouses.Warehouse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DDDSample1.Domain.Deliveries.Delivery", b =>
                {
                    b.OwnsOne("DDDSample1.Domain.Deliveries.Time", "LoadTime", b1 =>
                        {
                            b1.Property<string>("DeliveryId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Time1")
                                .HasColumnType("longtext");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Deliveries.Time", "UnloadTime", b1 =>
                        {
                            b1.Property<string>("DeliveryId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Time1")
                                .HasColumnType("longtext");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Warehouses.WarehouseId", "WarehouseId", b1 =>
                        {
                            b1.Property<string>("DeliveryId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("WarehouseIdentifier")
                                .HasColumnType("longtext");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Deliveries.DeliveryDate", "DeliveryDate", b1 =>
                        {
                            b1.Property<string>("DeliveryId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("DelDate")
                                .HasColumnType("longtext");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Deliveries.DeliveryId", "DeliveryId", b1 =>
                        {
                            b1.Property<string>("DeliveryId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("DeliveryIdentifier")
                                .HasColumnType("longtext");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Deliveries.Mass", "Mass", b1 =>
                        {
                            b1.Property<string>("DeliveryId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Mass1")
                                .HasColumnType("longtext");

                            b1.HasKey("DeliveryId");

                            b1.ToTable("Deliveries");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryId");
                        });

                    b.Navigation("DeliveryDate");

                    b.Navigation("DeliveryId");

                    b.Navigation("LoadTime");

                    b.Navigation("Mass");

                    b.Navigation("UnloadTime");

                    b.Navigation("WarehouseId");
                });

            modelBuilder.Entity("DDDSample1.Domain.Orders.Order", b =>
                {
                    b.OwnsOne("DDDSample1.Domain.Orders.OrderDescription", "Description", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("description")
                                .HasColumnType("longtext");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Orders.OrderId", "OrderId", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("OrderIdentifier")
                                .HasColumnType("longtext");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Description");

                    b.Navigation("OrderId");
                });

            modelBuilder.Entity("DDDSample1.Domain.Warehouses.Warehouse", b =>
                {
                    b.OwnsOne("DDDSample1.Domain.Warehouses.WarehouseId", "WarehouseId", b1 =>
                        {
                            b1.Property<string>("WarehouseId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("WarehouseIdentifier")
                                .HasColumnType("longtext");

                            b1.HasKey("WarehouseId");

                            b1.ToTable("Warehouses");

                            b1.WithOwner()
                                .HasForeignKey("WarehouseId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Warehouses.WarehouseAddress", "WarehouseAddress", b1 =>
                        {
                            b1.Property<string>("WarehouseId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("wh_address")
                                .HasColumnType("longtext");

                            b1.HasKey("WarehouseId");

                            b1.ToTable("Warehouses");

                            b1.WithOwner()
                                .HasForeignKey("WarehouseId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Warehouses.WarehouseDesignation", "WarehouseDesignation", b1 =>
                        {
                            b1.Property<string>("WarehouseId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("wh_designation")
                                .HasColumnType("longtext");

                            b1.HasKey("WarehouseId");

                            b1.ToTable("Warehouses");

                            b1.WithOwner()
                                .HasForeignKey("WarehouseId");
                        });

                    b.OwnsOne("DDDSample1.Domain.Warehouses.WarehouseGeoCoord", "WarehouseGeoCoord", b1 =>
                        {
                            b1.Property<string>("WarehouseId")
                                .HasColumnType("varchar(255)");

                            b1.Property<bool>("Active")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("wh_geoCoords")
                                .HasColumnType("longtext");

                            b1.HasKey("WarehouseId");

                            b1.ToTable("Warehouses");

                            b1.WithOwner()
                                .HasForeignKey("WarehouseId");
                        });

                    b.Navigation("WarehouseAddress");

                    b.Navigation("WarehouseDesignation");

                    b.Navigation("WarehouseGeoCoord");

                    b.Navigation("WarehouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
