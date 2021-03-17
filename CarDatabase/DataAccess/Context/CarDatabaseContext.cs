using CarDatabase.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarDatabase.DataAccess.Context
{
    public class CarDatabaseContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(builder =>
            {
                builder.Property(t => t.CarId).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                builder.Property(t => t.Brand).IsRequired();
                
                builder
                    .HasOne(t => t.Owner)
                    .WithMany(e => e.Cars);
            });

            modelBuilder.Entity<Owner>(builder =>
            {
                builder.Property(t => t.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                builder.Property(t => t.Name).IsRequired();
                builder.Property(t => t.LastName).IsRequired();
            });
        }
    }
}