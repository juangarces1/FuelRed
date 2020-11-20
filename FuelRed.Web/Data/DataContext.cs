using FuelRed.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FuelRed.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<StationEntity> Stations { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }
     
        public DbSet<ProductEntity> Products { get; set; }
     
        public DbSet<BankEntity> Banks { get; set; }
     
        public DbSet<TransactionEntity> Transactions { get; set; }
      
        public DbSet<PaymentEntity> Payments { get; set; }

        public DbSet<DispenserEntity> Dispensers { get; set; }

        public DbSet<HoseEntity> Hoses { get; set; }

        public DbSet<MedTemp> MedTemps { get; set; }

        public DbSet<MeaDisp> MeaDisps { get; set; }

        public DbSet<MeaItem> MeaItems { get; set; }


        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Compartment> Compartments { get; set; }

        public DbSet<TruckTank> TruckTanks { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Download> Downloads { get; set; }

        public DbSet<ItemTank> ItemTanks { get; set; }

        public DbSet<ItemTankTemp> ItemTankTemps { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UnitTemp> UnitTemps { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StationEntity>()
                .HasIndex(t => t.Name)
                .IsUnique();     

          

        }




        public DbSet<FuelRed.Web.Data.Entities.Seraphin> Seraphin { get; set; }
    }
}
