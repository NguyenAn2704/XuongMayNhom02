﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XuongMay_Nhom2.Data;

#nullable disable

namespace XuongMay_Nhom2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240820211919_TaoCSDL")]
    partial class TaoCSDL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XuongMay_Nhom2.Data.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasDefaultValue("Nam");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("DeliveryDeadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Unitprice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.ProductionLine", b =>
                {
                    b.Property<int>("ProductionLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionLineId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfEmployees")
                        .HasColumnType("int");

                    b.Property<string>("ProductionLineName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductionLineId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProductionLine", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionLineId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TaskId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductionLineId");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Employee", b =>
                {
                    b.HasOne("XuongMay_Nhom2.Data.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Order", b =>
                {
                    b.HasOne("XuongMay_Nhom2.Data.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Product", b =>
                {
                    b.HasOne("XuongMay_Nhom2.Data.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.ProductionLine", b =>
                {
                    b.HasOne("XuongMay_Nhom2.Data.Employee", "Employee")
                        .WithMany("ProductionLines")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Task", b =>
                {
                    b.HasOne("XuongMay_Nhom2.Data.Order", "Order")
                        .WithMany("Tasks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XuongMay_Nhom2.Data.ProductionLine", "ProductionLine")
                        .WithMany("Tasks")
                        .HasForeignKey("ProductionLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductionLine");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Employee", b =>
                {
                    b.Navigation("ProductionLines");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Order", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.ProductionLine", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("XuongMay_Nhom2.Data.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
