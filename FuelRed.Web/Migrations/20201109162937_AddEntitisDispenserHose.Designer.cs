﻿// <auto-generated />
using System;
using FuelRed.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FuelRed.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201109162937_AddEntitisDispenserHose")]
    partial class AddEntitisDispenserHose
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

                    b.Property<string>("Initials");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.DispenserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("StationEntityId");

                    b.HasKey("Id");

                    b.HasIndex("StationEntityId");

                    b.ToTable("Dispensers");
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.HoseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DispenserEntityId");

                    b.Property<int>("Number");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DispenserEntityId");

                    b.ToTable("HoseEntity");
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

                    b.Property<string>("DocumentNumber")
                        .IsRequired();

                    b.Property<int>("PaymentStatus");

                    b.Property<string>("UserId");

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

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PicturePath");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("StationId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StationId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.DispenserEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity")
                        .WithMany("Dispenser")
                        .HasForeignKey("StationEntityId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Employees")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.HoseEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.DispenserEntity")
                        .WithMany("Hoses")
                        .HasForeignKey("DispenserEntityId");
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Users")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
