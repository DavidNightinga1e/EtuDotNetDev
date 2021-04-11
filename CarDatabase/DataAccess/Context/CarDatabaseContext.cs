using CarDatabase.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarDatabase.DataAccess.Context
{
    public class CarDatabaseContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarOwner> Owners { get; set; }

        public CarDatabaseContext(DbContextOptions<CarDatabaseContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(builder =>
            {
                builder.Property(t => t.CarId).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                builder.Property(t => t.Brand).IsRequired();
                
                builder
                    .HasOne(t => t.CarOwner)
                    .WithMany(e => e.Cars);
            });

            modelBuilder.Entity<CarOwner>(builder =>
            {
                builder.Property(t => t.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                builder.Property(t => t.FirstName).IsRequired();
                builder.Property(t => t.LastName).IsRequired();
            });
        }
    }
}