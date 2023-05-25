using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TourismInternational.Models.EF;

public partial class LocationDbContext : DbContext
{
    public LocationDbContext()
    {
    }

    public LocationDbContext(DbContextOptions<LocationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TouristLocation> TouristLocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:tourismlimiteddb.database.windows.net,1433;Initial Catalog=LocationDB;Persist Security Info=False;User ID=rishabh;Password=1@password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TouristLocation>(entity =>
        {
            entity.HasKey(e => e.PlaceId).HasName("PK__touristL__E1216A36D25EE41C");

            entity.ToTable("touristLocation");

            entity.Property(e => e.PlaceId)
                .ValueGeneratedNever()
                .HasColumnName("placeId");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.LocationImage)
                .IsUnicode(false)
                .HasColumnName("locationImage");
            entity.Property(e => e.LocationName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("locationName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
