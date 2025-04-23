using System;
using System.Collections.Generic;
using Backend.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class MaindbContext : DbContext
{
    public MaindbContext()
    {
    }

    public MaindbContext(DbContextOptions<MaindbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EpEmployee> EpEmployees { get; set; }

    public virtual DbSet<EpEmployeePosition> EpEmployeePositionIds { get; set; }

    public virtual DbSet<EpEstate> EpEstates { get; set; }

    public virtual DbSet<EpEstateDetail> EpEstateDetails { get; set; }

    public virtual DbSet<EpEstateImg> EpEstateImgs { get; set; }

    public virtual DbSet<EpUser> EpUsers { get; set; }

    public virtual DbSet<EpUserFavorite> EpUserFavorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EpEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__EP_emplo__C52E0BA84B3583BE");

            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Position).WithMany(p => p.EpEmployees).HasConstraintName("FK__EP_employ__posit__6B24EA82");
        });

        modelBuilder.Entity<EpEmployeePosition>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__employee__99A0E7A4F72D3F2E");
        });

        modelBuilder.Entity<EpEstate>(entity =>
        {
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employee).WithMany(p => p.EpEstates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EP_estate_EP_employee");
        });

        modelBuilder.Entity<EpEstateDetail>(entity =>
        {
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Estate).WithMany(p => p.EpEstateDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EP_estate_detail_EP_estate_detail");
        });

        modelBuilder.Entity<EpEstateImg>(entity =>
        {
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Estate).WithMany(p => p.EpEstateImgs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EP_estate_img_EP_estate");
        });

        modelBuilder.Entity<EpUser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__EP_user__CBA1B2579C9D5819");

            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EpUserFavorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__EP_favor__46ACF4CBA9A9AB2A");

            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Estate).WithMany(p => p.EpUserFavorites).HasConstraintName("FK__EP_favori__estat__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.EpUserFavorites).HasConstraintName("FK__EP_favori__useri__6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
