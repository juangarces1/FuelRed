﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Soccer.Web.Data;

namespace FuelRed.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200528003516_AddImageFileToproducts")]
    partial class AddImageFileToproducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FuelRed.Web.Data.BankEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.EmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PicturePath");

                    b.Property<int?>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.PaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amount")
                        .IsRequired();

                    b.Property<int?>("BankId");

                    b.Property<int>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<string>("DocumentNumber");

                    b.Property<int>("PaymentStatus");

                    b.Property<string>("UserId");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ImagePath");

                    b.Property<decimal>("Price");

                    b.Property<int?>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.StationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LegalCertificate")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LogoPath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.TransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dispenser")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasMaxLength(10);

                    b.Property<int?>("StationId");

                    b.Property<decimal>("Volumen")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StationId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PicturePath");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("UserEntity");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Employees")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.PaymentEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.BankEntity", "Bank")
                        .WithMany("Payments")
                        .HasForeignKey("BankId");

                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.ProductEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Products")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.TransactionEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.EmployeeEntity", "Employee")
                        .WithMany("TransactionEntities")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Transactions")
                        .HasForeignKey("StationId");
                });
#pragma warning restore 612, 618
        }
    }
}
