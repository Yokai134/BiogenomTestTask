using Biogenom.Model;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Data
{
    public class BiogenomDbContext : DbContext
    {
        public BiogenomDbContext(DbContextOptions<BiogenomDbContext> options) : base(options) { }
        public DbSet<ActivityLevel> ActivityLevels { get; set; }
        public DbSet<ConsumptionFrequency> ConsumptionFrequencies { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductConsumption> ProductConsumptions { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserSupplement> UserSupplements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка ограничений и связей
            modelBuilder.Entity<ActivityLevel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("activitylevels_pkey");

                entity.ToTable("activitylevels");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NameLevels)
                    .HasMaxLength(50)
                    .HasColumnName("namelevels");
            });

            modelBuilder.Entity<ConsumptionFrequency>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("consumptionfrequencies_pkey");

                entity.ToTable("consumptionfrequencies");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NameFrequencies)
                    .HasMaxLength(50)
                    .HasColumnName("namefrequencies");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("measurementunits_pkey");

                entity.ToTable("measurementunits");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NameUnit)
                    .HasMaxLength(10)
                    .HasColumnName("nameunit");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("productcategories_pkey");

                entity.ToTable("productcategories");

                entity.HasIndex(e => e.NameCategories, "productcategories_namecategories_key").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NameCategories)
                    .HasMaxLength(50)
                    .HasColumnName("namecategories");
            });

            modelBuilder.Entity<ProductConsumption>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("productconsumption_pkey");

                entity.ToTable("productconsumption");

                entity.HasIndex(e => new { e.UserId, e.ProductTypeId }, "unique_user_product_entry").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.AmountUnitId).HasColumnName("amountunitid");
                entity.Property(e => e.FrequencyId).HasColumnName("frequencyid");
                entity.Property(e => e.ProductTypeId).HasColumnName("producttypeid");
                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.HasOne(d => d.AmountUnit).WithMany(p => p.ProductConsumptions)
                    .HasForeignKey(d => d.AmountUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productconsumption_amountunitid_fkey");

                entity.HasOne(d => d.Frequency).WithMany(p => p.ProductConsumptions)
                    .HasForeignKey(d => d.FrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productconsumption_frequencyid_fkey");

                entity.HasOne(d => d.ProductType).WithMany(p => p.ProductConsumptions)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productconsumption_producttypeid_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.ProductConsumptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productconsumption_userid_fkey");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("producttypes_pkey");

                entity.ToTable("producttypes");

                entity.HasIndex(e => new { e.CategoryId, e.NameProduct }, "unique_product_type").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CategoryId).HasColumnName("categoryid");
                entity.Property(e => e.NameProduct)
                    .HasMaxLength(150)
                    .HasColumnName("nameproduct");

                entity.HasOne(d => d.Category).WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("producttypes_idcategory_fkey");
            });

            modelBuilder.Entity<Supplement>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("supplements_pkey");

                entity.ToTable("supplements");

                entity.HasIndex(e => e.NameSupplements, "supplements_namesupplements_key").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NameSupplements)
                    .HasMaxLength(150)
                    .HasColumnName("namesupplements");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BirthDate).HasColumnName("birthdate");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");
                entity.Property(e => e.Height).HasColumnName("height");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");
                entity.Property(e => e.PatronomycName)
                    .HasMaxLength(50)
                    .HasColumnName("patronomycname");
                entity.Property(e => e.Weight)
                    .HasPrecision(5, 2)
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("useractivity_pkey");

                entity.ToTable("useractivity");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ActivityLevelId).HasColumnName("activitylevelid");
                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.HasOne(d => d.ActivityLevel).WithMany(p => p.UserActivities)
                    .HasForeignKey(d => d.ActivityLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("useractivity_activitylevelid_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.UserActivities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("useractivity_userid_fkey");
            });

            modelBuilder.Entity<UserSupplement>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("usersupplements_pkey");

                entity.ToTable("usersupplements");

                entity.HasIndex(e => new { e.UserId, e.SupplementId }, "unique_user_supplement").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SupplementId).HasColumnName("supplementid");
                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.HasOne(d => d.Supplement).WithMany(p => p.UserSupplements)
                    .HasForeignKey(d => d.SupplementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usersupplements_supplementid_fkey");

                entity.HasOne(d => d.User).WithMany(p => p.UserSupplements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usersupplements_userid_fkey");
            });
         
        }     
    }
}
