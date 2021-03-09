using Brivent.Modules.ParcelLockers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Brivent.Modules.ParcelLockers.Infrastructure
{
    public class ParcelLockersContext : DbContext
    {
        public DbSet<ParcelLocker> ParcelLockers { get; set; }

        public ParcelLockersContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParcelLocker>()
                .ToTable("ParcelLockers")
                .OwnsOne(x => x.Localization, y =>
                {
                    y.ToTable("ParcelLockersLocalization");
                    y.WithOwner().HasForeignKey("Id");
                })
                .OwnsMany(x => x.Parcels, y =>
                {
                    y.ToTable("ParcelLockersContent");
                    y.WithOwner().HasForeignKey("Id");
                });
        }
    }
}