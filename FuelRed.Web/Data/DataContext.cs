using Microsoft.EntityFrameworkCore;
using FuelRed.Web.Data.Entities;
using FuelRed.Web.Data;

namespace Soccer.Web.Data
{
    public class DataContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StationEntity>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }




    }
}
