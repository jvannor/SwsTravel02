using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccomodationClass> AccomodationClasses { get; set; } = null!;
        public virtual DbSet<AccomodationMap> AccomodationMaps { get; set; } = null!;
        public virtual DbSet<AccomodationMapType> AccomodationMapTypes { get; set; } = null!;
        public virtual DbSet<ContactMechanism> ContactMechanisms { get; set; } = null!;
        public virtual DbSet<DayOfTheWeek> DayOfTheWeeks { get; set; } = null!;
        public virtual DbSet<Facility> Facilities { get; set; } = null!;
        public virtual DbSet<FacilityContactMechanism> FacilityContactMechanisms { get; set; } = null!;
        public virtual DbSet<FacilityType> FacilityTypes { get; set; } = null!;
        public virtual DbSet<FixedAsset> FixedAssets { get; set; } = null!;
        public virtual DbSet<FixedAssetType> FixedAssetTypes { get; set; } = null!;
        public virtual DbSet<OrganizationRole> OrganizationRoles { get; set; } = null!;
        public virtual DbSet<OrganizationRoleType> OrganizationRoleTypes { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductCategoryClassification> ProductCategoryClassifications { get; set; } = null!;
        public virtual DbSet<RegularlyScheduledTime> RegularlyScheduledTimes { get; set; } = null!;
        public virtual DbSet<ScheduledTransportation> ScheduledTransportations { get; set; } = null!;
        public virtual DbSet<ScheduledTransportationOffering> ScheduledTransportationOfferings { get; set; } = null!;
        public virtual DbSet<TravelProduct> TravelProducts { get; set; } = null!;
        public virtual DbSet<TravelProductReferenceNumber> TravelProductReferenceNumbers { get; set; } = null!;
        public virtual DbSet<TravelProductType> TravelProductTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccomodationClass>(entity =>
            {
                entity.ToTable("AccomodationClass");

                entity.Property(e => e.AccomodationClassId).HasColumnName("AccomodationClassID");

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<AccomodationMap>(entity =>
            {
                entity.HasKey(e => new { e.AccomodationMapTypeId, e.AccomodationClassId, e.FixedAssetId, e.NumberOfSpaces })
                    .HasName("PK_AccomondationMap");

                entity.ToTable("AccomodationMap");

                entity.Property(e => e.AccomodationMapTypeId).HasColumnName("AccomodationMapTypeID");

                entity.Property(e => e.AccomodationClassId).HasColumnName("AccomodationClassID");

                entity.Property(e => e.FixedAssetId).HasColumnName("FixedAssetID");

                entity.HasOne(d => d.AccomodationClass)
                    .WithMany(p => p.AccomodationMaps)
                    .HasForeignKey(d => d.AccomodationClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccomodationClassAccomodationMap");

                entity.HasOne(d => d.AccomodationMapType)
                    .WithMany(p => p.AccomodationMaps)
                    .HasForeignKey(d => d.AccomodationMapTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccomodationMapTypeAccomodationMap");

                entity.HasOne(d => d.FixedAsset)
                    .WithMany(p => p.AccomodationMaps)
                    .HasForeignKey(d => d.FixedAssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAssetAccomodationMap");
            });

            modelBuilder.Entity<AccomodationMapType>(entity =>
            {
                entity.ToTable("AccomodationMapType");

                entity.HasIndex(e => e.AccomodationMapTypeName, "UC_AccomodationMapTypeName")
                    .IsUnique();

                entity.Property(e => e.AccomodationMapTypeId).HasColumnName("AccomodationMapTypeID");

                entity.Property(e => e.AccomodationMapTypeName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<ContactMechanism>(entity =>
            {
                entity.ToTable("ContactMechanism");

                entity.HasIndex(e => e.ContactMechanismName, "UC_ContactMechanismName")
                    .IsUnique();

                entity.Property(e => e.ContactMechanismId).HasColumnName("ContactMechanismID");

                entity.Property(e => e.ContactMechanismName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(512);
            });

            modelBuilder.Entity<DayOfTheWeek>(entity =>
            {
                entity.ToTable("DayOfTheWeek");

                entity.HasIndex(e => e.DayName, "UC_DayName")
                    .IsUnique();

                entity.Property(e => e.DayOfTheWeekId).HasColumnName("DayOfTheWeekID");

                entity.Property(e => e.DayName).HasMaxLength(32);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.HasIndex(e => e.FacilityName, "UC_FAcilityName")
                    .IsUnique();

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.FacilityName).HasMaxLength(256);

                entity.Property(e => e.FacilityTypeId).HasColumnName("FacilityTypeID");

                entity.Property(e => e.PartOfFacilityId).HasColumnName("PartOfFacilityID");

                entity.Property(e => e.PartOfFacilityTypeId).HasColumnName("PartOfFacilityTypeID");

                entity.HasOne(d => d.FacilityType)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.FacilityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityTypeFacility");

                entity.HasOne(d => d.PartOfFacility)
                    .WithMany(p => p.InversePartOfFacility)
                    .HasForeignKey(d => d.PartOfFacilityId)
                    .HasConstraintName("FK_FacilityFacility");
            });

            modelBuilder.Entity<FacilityContactMechanism>(entity =>
            {
                entity.HasKey(e => new { e.ContactMechanismId, e.FacilityId });

                entity.ToTable("FacilityContactMechanism");

                entity.Property(e => e.ContactMechanismId).HasColumnName("ContactMechanismID");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");
            });

            modelBuilder.Entity<FacilityType>(entity =>
            {
                entity.ToTable("FacilityType");

                entity.HasIndex(e => e.FacilityTypeName, "UC_FacilityTypeName")
                    .IsUnique();

                entity.Property(e => e.FacilityTypeId).HasColumnName("FacilityTypeID");

                entity.Property(e => e.FacilityTypeName).HasMaxLength(256);
            });

            modelBuilder.Entity<FixedAsset>(entity =>
            {
                entity.ToTable("FixedAsset");

                entity.HasIndex(e => e.FixedAssetName, "UC_FixedAssetName")
                    .IsUnique();

                entity.Property(e => e.FixedAssetId).HasColumnName("FixedAssetID");

                entity.Property(e => e.Capacity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateAcquired).HasColumnType("date");

                entity.Property(e => e.DateLastServiced).HasColumnType("date");

                entity.Property(e => e.DateNextService).HasColumnType("date");

                entity.Property(e => e.FixedAssetName).HasMaxLength(256);

                entity.Property(e => e.FixedAssetTypeId).HasColumnName("FixedAssetTypeID");

                entity.Property(e => e.OrganizationRoleTypeId).HasColumnName("OrganizationRoleTypeID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.HasOne(d => d.FixedAssetType)
                    .WithMany(p => p.FixedAssets)
                    .HasForeignKey(d => d.FixedAssetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAssetTypeFixedAsset");

                entity.HasOne(d => d.TravelProduct)
                    .WithMany(p => p.FixedAssets)
                    .HasForeignKey(d => d.TravelProductId)
                    .HasConstraintName("FK_TravelProductFixedAsset");

                entity.HasOne(d => d.OrganizationRole)
                    .WithMany(p => p.FixedAssets)
                    .HasForeignKey(d => new { d.PartyId, d.OrganizationRoleTypeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrgniazationRoleFixedAsset");
            });

            modelBuilder.Entity<FixedAssetType>(entity =>
            {
                entity.ToTable("FixedAssetType");

                entity.HasIndex(e => e.FixedAssetTypeName, "UC_FixedAssetTypeName")
                    .IsUnique();

                entity.Property(e => e.FixedAssetTypeId).HasColumnName("FixedAssetTypeID");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.FixedAssetTypeName).HasMaxLength(256);
            });

            modelBuilder.Entity<OrganizationRole>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.OrganizationRoleTypeId });

                entity.ToTable("OrganizationRole");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.OrganizationRoleTypeId).HasColumnName("OrganizationRoleTypeID");

                entity.HasOne(d => d.OrganizationRoleType)
                    .WithMany(p => p.OrganizationRoles)
                    .HasForeignKey(d => d.OrganizationRoleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationRoleTypeOrganizationRole");
            });

            modelBuilder.Entity<OrganizationRoleType>(entity =>
            {
                entity.ToTable("OrganizationRoleType");

                entity.HasIndex(e => e.OrganizationRoleName, "UC_OrganizationRoleName")
                    .IsUnique();

                entity.Property(e => e.OrganizationRoleTypeId).HasColumnName("OrganizationRoleTypeID");

                entity.Property(e => e.OrganizationRoleName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.HasIndex(e => e.ProductCategoryName, "UC_ProductCategoryName")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ProductCategoryName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductCategoryClassification>(entity =>
            {
                entity.HasKey(e => new { e.ProductCategoryId, e.TravelProductId, e.FromDate });

                entity.ToTable("ProductCategoryClassification");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Comments).HasMaxLength(512);

                entity.Property(e => e.ThruDate).HasColumnType("date");
            });

            modelBuilder.Entity<RegularlyScheduledTime>(entity =>
            {
                entity.HasKey(e => e.FromDate);

                entity.ToTable("RegularlyScheduledTime");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.DayIdOfferedArriving).HasColumnName("DayID_OfferedArriving");

                entity.Property(e => e.DayIdOfferedDeparting).HasColumnName("DayID_OfferedDeparting");

                entity.Property(e => e.ThruDate).HasColumnType("date");

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.HasOne(d => d.DayIdOfferedArrivingNavigation)
                    .WithMany(p => p.RegularlyScheduledTimeDayIdOfferedArrivingNavigations)
                    .HasForeignKey(d => d.DayIdOfferedArriving)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DayOfTheWeekRegularlyScheduledTime_OfferedArriving");

                entity.HasOne(d => d.DayIdOfferedDepartingNavigation)
                    .WithMany(p => p.RegularlyScheduledTimeDayIdOfferedDepartingNavigations)
                    .HasForeignKey(d => d.DayIdOfferedDeparting)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DayOfTheWeekRegularlyScheduledTime_OdderedDeparting");

                entity.HasOne(d => d.TravelProduct)
                    .WithMany(p => p.RegularlyScheduledTimes)
                    .HasForeignKey(d => d.TravelProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelProductRegularlyScheduledTime");
            });

            modelBuilder.Entity<ScheduledTransportation>(entity =>
            {
                entity.HasKey(e => new { e.FixedAssetId, e.TravelProductId, e.ScheduledTransportationId });

                entity.ToTable("ScheduledTransportation");

                entity.Property(e => e.FixedAssetId).HasColumnName("FixedAssetID");

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.Property(e => e.ScheduledTransportationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ScheduledTransportationID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.OrganizationRoleTypeId).HasColumnName("OrganizationRoleTypeID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.FixedAsset)
                    .WithMany(p => p.ScheduledTransportations)
                    .HasForeignKey(d => d.FixedAssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAssetScheduledTransportation");

                entity.HasOne(d => d.TravelProduct)
                    .WithMany(p => p.ScheduledTransportations)
                    .HasForeignKey(d => d.TravelProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelProductScheduledTransportation");

                entity.HasOne(d => d.OrganizationRole)
                    .WithMany(p => p.ScheduledTransportations)
                    .HasForeignKey(d => new { d.PartyId, d.OrganizationRoleTypeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrgniazationRoleScheduledTransportation");
            });

            modelBuilder.Entity<ScheduledTransportationOffering>(entity =>
            {
                entity.HasKey(e => new { e.FixedAssetId, e.TravelProductId, e.ScheduledTransportationId, e.ScheduledTransportationOfferingId });

                entity.ToTable("ScheduledTransportationOffering");

                entity.Property(e => e.FixedAssetId).HasColumnName("FixedAssetID");

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.Property(e => e.ScheduledTransportationId).HasColumnName("ScheduledTransportationID");

                entity.Property(e => e.ScheduledTransportationOfferingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ScheduledTransportationOfferingID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ThruDate).HasColumnType("date");

                entity.HasOne(d => d.ScheduledTransportation)
                    .WithMany(p => p.ScheduledTransportationOfferings)
                    .HasForeignKey(d => new { d.FixedAssetId, d.TravelProductId, d.ScheduledTransportationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduledTransportationScheduledTransportationOffering");
            });

            modelBuilder.Entity<TravelProduct>(entity =>
            {
                entity.ToTable("TravelProduct");

                entity.HasIndex(e => e.TravelProductName, "UC_TravelProductName")
                    .IsUnique();

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.FacilityIdGoingTo).HasColumnName("FacilityID_GoingTo");

                entity.Property(e => e.FacilityIdOriginatingFrom).HasColumnName("FacilityID_OriginatingFrom");

                entity.Property(e => e.TravelProductName).HasMaxLength(256);

                entity.Property(e => e.TravelProductTypeId).HasColumnName("TravelProductTypeID");

                entity.HasOne(d => d.FacilityIdGoingToNavigation)
                    .WithMany(p => p.TravelProductFacilityIdGoingToNavigations)
                    .HasForeignKey(d => d.FacilityIdGoingTo)
                    .HasConstraintName("FK_FacilityGoingToTravelProduct");

                entity.HasOne(d => d.FacilityIdOriginatingFromNavigation)
                    .WithMany(p => p.TravelProductFacilityIdOriginatingFromNavigations)
                    .HasForeignKey(d => d.FacilityIdOriginatingFrom)
                    .HasConstraintName("FK_FacilityOriginatingFromTravelProduct");

                entity.HasOne(d => d.TravelProductType)
                    .WithMany(p => p.TravelProducts)
                    .HasForeignKey(d => d.TravelProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelProductTypeTravelProduct");

                entity.HasMany(d => d.TravelProductIdFors)
                    .WithMany(p => p.TravelProductIdOfs)
                    .UsingEntity<Dictionary<string, object>>(
                        "TravelProductComplement",
                        l => l.HasOne<TravelProduct>().WithMany().HasForeignKey("TravelProductIdFor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TravelProductTravelProductComplementFor"),
                        r => r.HasOne<TravelProduct>().WithMany().HasForeignKey("TravelProductIdOf").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TravelProductTravelProductComplementOf"),
                        j =>
                        {
                            j.HasKey("TravelProductIdOf", "TravelProductIdFor");

                            j.ToTable("TravelProductComplement");

                            j.IndexerProperty<int>("TravelProductIdOf").HasColumnName("TravelProductID_Of");

                            j.IndexerProperty<int>("TravelProductIdFor").HasColumnName("TravelProductID_For");
                        });

                entity.HasMany(d => d.TravelProductIdOfs)
                    .WithMany(p => p.TravelProductIdFors)
                    .UsingEntity<Dictionary<string, object>>(
                        "TravelProductComplement",
                        l => l.HasOne<TravelProduct>().WithMany().HasForeignKey("TravelProductIdOf").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TravelProductTravelProductComplementOf"),
                        r => r.HasOne<TravelProduct>().WithMany().HasForeignKey("TravelProductIdFor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TravelProductTravelProductComplementFor"),
                        j =>
                        {
                            j.HasKey("TravelProductIdOf", "TravelProductIdFor");

                            j.ToTable("TravelProductComplement");

                            j.IndexerProperty<int>("TravelProductIdOf").HasColumnName("TravelProductID_Of");

                            j.IndexerProperty<int>("TravelProductIdFor").HasColumnName("TravelProductID_For");
                        });
            });

            modelBuilder.Entity<TravelProductReferenceNumber>(entity =>
            {
                entity.HasKey(e => new { e.TravelProductReferenceNumberId, e.TravelProductId, e.FromDate });

                entity.ToTable("TravelProductReferenceNumber");

                entity.Property(e => e.TravelProductReferenceNumberId)
                    .HasMaxLength(32)
                    .HasColumnName("TravelProductReferenceNumberID");

                entity.Property(e => e.TravelProductId).HasColumnName("TravelProductID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ThruDate).HasColumnType("date");

                entity.HasOne(d => d.TravelProduct)
                    .WithMany(p => p.TravelProductReferenceNumbers)
                    .HasForeignKey(d => d.TravelProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelProductTravelProductReferenceNumber");
            });

            modelBuilder.Entity<TravelProductType>(entity =>
            {
                entity.ToTable("TravelProductType");

                entity.HasIndex(e => e.TravelProductTypeName, "UC_TravelProductTypeName")
                    .IsUnique();

                entity.Property(e => e.TravelProductTypeId).HasColumnName("TravelProductTypeID");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.TravelProductTypeName).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
