using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PricingAPI.Models;

namespace PricingAPI.Data
{
    public partial class PricingContext : DbContext
    {
        public PricingContext()
        {
        }

        public PricingContext(DbContextOptions<PricingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GeographicBoundary> GeographicBoundaries { get; set; } = null!;
        public virtual DbSet<OrderValue> OrderValues { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<PartyType> PartyTypes { get; set; } = null!;
        public virtual DbSet<PriceComponent> PriceComponents { get; set; } = null!;
        public virtual DbSet<PriceComponentType> PriceComponentTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductFeature> ProductFeatures { get; set; } = null!;
        public virtual DbSet<QuantityBreak> QuantityBreaks { get; set; } = null!;
        public virtual DbSet<SaleType> SaleTypes { get; set; } = null!;
        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; } = null!;
        public virtual DbSet<UnitOfMeasureType> UnitOfMeasureTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeographicBoundary>(entity =>
            {
                entity.ToTable("GeographicBoundary");

                entity.HasIndex(e => e.Abbreviation, "UC_GeographicAbbreviation")
                    .IsUnique();

                entity.HasIndex(e => e.GeographicBoundaryName, "UC_GeographicBoundaryName")
                    .IsUnique();

                entity.HasIndex(e => e.GeographicCode, "UC_GeographicCode")
                    .IsUnique();

                entity.Property(e => e.GeographicBoundaryId).HasColumnName("GeographicBoundaryID");

                entity.Property(e => e.Abbreviation).HasMaxLength(16);

                entity.Property(e => e.GeographicBoundaryName).HasMaxLength(256);

                entity.Property(e => e.GeographicCode).HasMaxLength(32);
            });

            modelBuilder.Entity<OrderValue>(entity =>
            {
                entity.ToTable("OrderValue");

                entity.Property(e => e.OrderValueId).HasColumnName("OrderValueID");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.HasIndex(e => e.OrganizationName, "UC_OrganizationOrganizationName")
                    .IsUnique();

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationName).HasMaxLength(256);
            });

            modelBuilder.Entity<PartyType>(entity =>
            {
                entity.ToTable("PartyType");

                entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<PriceComponent>(entity =>
            {
                entity.HasKey(e => new { e.PriceComponentId, e.PriceComponentTypeId });

                entity.ToTable("PriceComponent");

                entity.Property(e => e.PriceComponentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PriceComponentID");

                entity.Property(e => e.PriceComponentTypeId).HasColumnName("PriceComponentTypeID");

                entity.Property(e => e.Comment).HasMaxLength(512);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Percentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ThruDate).HasColumnType("date");

                entity.HasOne(d => d.PriceComponentType)
                    .WithMany(p => p.PriceComponents)
                    .HasForeignKey(d => d.PriceComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceComponentTypePriceComponent");
            });

            modelBuilder.Entity<PriceComponentType>(entity =>
            {
                entity.ToTable("PriceComponentType");

                entity.HasIndex(e => e.PriceComponentTypeName, "UC_PriceComponentTypePriceComponentName")
                    .IsUnique();

                entity.Property(e => e.PriceComponentTypeId).HasColumnName("PriceComponentTypeID");

                entity.Property(e => e.PriceComponentTypeName).HasMaxLength(256);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductName, "UC_ProductProductName")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.ToTable("ProductFeature");

                entity.Property(e => e.ProductFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductFeatureID");

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<QuantityBreak>(entity =>
            {
                entity.ToTable("QuantityBreak");

                entity.Property(e => e.QuantityBreakId).HasColumnName("QuantityBreakID");
            });

            modelBuilder.Entity<SaleType>(entity =>
            {
                entity.ToTable("SaleType");

                entity.Property(e => e.SaleTypeId).HasColumnName("SaleTypeID");

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.HasKey(e => new { e.UnitOfMeasureId, e.UnitOfMeasureTypeId });

                entity.ToTable("UnitOfMeasure");

                entity.HasIndex(e => e.Abbreviation, "UC_UnitOfMeasureAbbreviation")
                    .IsUnique();

                entity.Property(e => e.UnitOfMeasureId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UnitOfMeasureID");

                entity.Property(e => e.UnitOfMeasureTypeId).HasColumnName("UnitOfMeasureTypeID");

                entity.Property(e => e.Abbreviation).HasMaxLength(16);

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.HasOne(d => d.UnitOfMeasureType)
                    .WithMany(p => p.UnitOfMeasures)
                    .HasForeignKey(d => d.UnitOfMeasureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitOfMeaaureTypeUnitOfMeasure");
            });

            modelBuilder.Entity<UnitOfMeasureType>(entity =>
            {
                entity.ToTable("UnitOfMeasureType");

                entity.HasIndex(e => e.UnitOfMeasureTypeName, "UC_UnitOfMeasureTypeName")
                    .IsUnique();

                entity.Property(e => e.UnitOfMeasureTypeId).HasColumnName("UnitOfMeasureTypeID");

                entity.Property(e => e.UnitOfMeasureTypeName).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
