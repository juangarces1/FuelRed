﻿// <auto-generated />
using System;
using FuelRed.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FuelRed.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Compartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<int>("Number");

                    b.Property<int?>("TruckTankId");

                    b.HasKey("Id");

                    b.HasIndex("TruckTankId");

                    b.ToTable("Compartments");
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Download", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Area");

                    b.Property<bool>("CisternEscape");

                    b.Property<bool>("Container");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DriverId");

                    b.Property<DateTime>("EndHour");

                    b.Property<bool>("Exit");

                    b.Property<bool>("Extinguisher");

                    b.Property<bool>("Marched");

                    b.Property<int>("Number");

                    b.Property<string>("Observation");

                    b.Property<bool>("Recope");

                    b.Property<bool>("Sample");

                    b.Property<bool>("Security");

                    b.Property<DateTime>("StartHour");

                    b.Property<int?>("StationId");

                    b.Property<int?>("TruckId");

                    b.Property<string>("UserId");

                    b.Property<bool>("ground");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("StationId");

                    b.HasIndex("TruckId");

                    b.HasIndex("UserId");

                    b.ToTable("Downloads");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Document");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int?>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Drivers");
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

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DispenserEntityId");

                    b.ToTable("Hoses");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.ItemTank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Color");

                    b.Property<int?>("CompartmentId");

                    b.Property<int?>("DownloadId");

                    b.Property<string>("Fuel");

                    b.Property<bool>("Sediments");

                    b.Property<int?>("TankId");

                    b.Property<int>("TypeFuel");

                    b.Property<bool>("Water");

                    b.HasKey("Id");

                    b.HasIndex("CompartmentId");

                    b.HasIndex("DownloadId");

                    b.HasIndex("TankId");

                    b.ToTable("ItemTanks");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.ItemTankTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Color");

                    b.Property<int?>("CompartmentId");

                    b.Property<string>("Fuel");

                    b.Property<bool>("Sediments");

                    b.Property<int?>("TankId");

                    b.Property<int>("TruckId");

                    b.Property<int>("TypeFuel");

                    b.Property<bool>("Water");

                    b.HasKey("Id");

                    b.HasIndex("CompartmentId");

                    b.HasIndex("TankId");

                    b.ToTable("ItemTankTemps");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.MeaDisp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndHour");

                    b.Property<int>("Number");

                    b.Property<string>("Observation");

                    b.Property<int?>("SeraphinId");

                    b.Property<DateTime>("StartHour");

                    b.Property<int?>("StationId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SeraphinId");

                    b.HasIndex("StationId");

                    b.HasIndex("UserId");

                    b.ToTable("MeaDisps");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.MeaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail");

                    b.Property<int?>("DispenserId");

                    b.Property<int?>("HoseId");

                    b.Property<decimal>("Md1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Md2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Md3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MeaDispId");

                    b.HasKey("Id");

                    b.HasIndex("DispenserId");

                    b.HasIndex("HoseId");

                    b.HasIndex("MeaDispId");

                    b.ToTable("MeaItems");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.MedTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail");

                    b.Property<int?>("DispenserId");

                    b.Property<int?>("HoseId");

                    b.Property<decimal>("Md1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Md2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Md3")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DispenserId");

                    b.HasIndex("HoseId");

                    b.ToTable("MedTemps");
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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Seraphin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Certifacate");

                    b.Property<int>("Gauge");

                    b.Property<int?>("StationId");

                    b.Property<int>("validity");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Seraphin");
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

                    b.Property<string>("LegalName")
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
                        .HasColumnType("decimal(18,2)")
                        .HasMaxLength(10);

                    b.Property<int?>("StationId");

                    b.Property<decimal>("Volumen")
                        .HasColumnType("decimal(18,2)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StationId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("StationId");

                    b.Property<string>("TankPlate")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.TruckTank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number");

                    b.Property<int?>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("TruckId");

                    b.ToTable("TruckTanks");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Buy");

                    b.Property<int>("EndLts");

                    b.Property<int>("EndPulg");

                    b.Property<int>("StartLts");

                    b.Property<int>("StartPulg");

                    b.Property<int>("TypeFuel");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.UnitTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Buy");

                    b.Property<int>("EndLts");

                    b.Property<int>("EndPulg");

                    b.Property<string>("Fuel");

                    b.Property<int>("StartLts");

                    b.Property<int>("StartPulg");

                    b.Property<int>("TypeFuel");

                    b.HasKey("Id");

                    b.ToTable("UnitTemps");
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Compartment", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.TruckTank")
                        .WithMany("Compartments")
                        .HasForeignKey("TruckTankId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.DispenserEntity", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity")
                        .WithMany("Dispensers")
                        .HasForeignKey("StationEntityId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Download", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany()
                        .HasForeignKey("StationId");

                    b.HasOne("FuelRed.Web.Data.Entities.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId");

                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Driver", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Drivers")
                        .HasForeignKey("StationId");
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.ItemTank", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.Compartment", "Compartment")
                        .WithMany()
                        .HasForeignKey("CompartmentId");

                    b.HasOne("FuelRed.Web.Data.Entities.Download")
                        .WithMany("ItemTanks")
                        .HasForeignKey("DownloadId");

                    b.HasOne("FuelRed.Web.Data.Entities.TruckTank", "Tank")
                        .WithMany()
                        .HasForeignKey("TankId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.ItemTankTemp", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.Compartment", "Compartment")
                        .WithMany()
                        .HasForeignKey("CompartmentId");

                    b.HasOne("FuelRed.Web.Data.Entities.TruckTank", "Tank")
                        .WithMany()
                        .HasForeignKey("TankId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.MeaDisp", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.Seraphin", "Seraphin")
                        .WithMany()
                        .HasForeignKey("SeraphinId");

                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany()
                        .HasForeignKey("StationId");

                    b.HasOne("FuelRed.Web.Data.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.MeaItem", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.DispenserEntity", "Dispenser")
                        .WithMany()
                        .HasForeignKey("DispenserId");

                    b.HasOne("FuelRed.Web.Data.Entities.HoseEntity", "Hose")
                        .WithMany()
                        .HasForeignKey("HoseId");

                    b.HasOne("FuelRed.Web.Data.Entities.MeaDisp")
                        .WithMany("MeaItems")
                        .HasForeignKey("MeaDispId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.MedTemp", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.DispenserEntity", "Dispenser")
                        .WithMany()
                        .HasForeignKey("DispenserId");

                    b.HasOne("FuelRed.Web.Data.Entities.HoseEntity", "Hose")
                        .WithMany()
                        .HasForeignKey("HoseId");
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Seraphin", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany()
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

            modelBuilder.Entity("FuelRed.Web.Data.Entities.Truck", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.StationEntity", "Station")
                        .WithMany("Trucks")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("FuelRed.Web.Data.Entities.TruckTank", b =>
                {
                    b.HasOne("FuelRed.Web.Data.Entities.Truck")
                        .WithMany("Tanks")
                        .HasForeignKey("TruckId");
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
