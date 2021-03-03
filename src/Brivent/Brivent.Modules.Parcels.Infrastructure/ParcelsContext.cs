using System;
using Brivent.Modules.Parcels.Domain;
using Microsoft.EntityFrameworkCore;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ParcelsContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }

        public ParcelsContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>(builder =>
            {
                builder.ToTable("Parcels");

                builder.HasKey(x => x.Id);
                builder.Property(x => x.Size);
            });
        }
    }
}