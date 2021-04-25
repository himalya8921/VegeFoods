using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VegeFoodsEntities.CustomEntities;

#nullable disable

namespace VegeFoodsEntities.Entities
{
    public partial class VegeDbContext : DbContext
    {
        public VegeDbContext()
        {
        }

        public VegeDbContext(DbContextOptions<VegeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserBilling> UserBilling { get; set; }
        public virtual DbSet<UserCart> UserCart { get; set; }
        public virtual DbSet<UserWishlist> UserWishlist { get; set; }

        public virtual DbSet<UserWishlistModel> UserWishlistModel { get; set; }

        public virtual DbSet<UserCartModel> UserCartModel { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-LI4AMOA3;Database=VegeFoodsdb;User Id=admin;Password=Admin@123456;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Products>(entity =>
            {
                
                 entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage).HasMaxLength(100);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {

                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserBilling>(entity =>
            {
                entity.HasKey(e => e.BillingId);

                entity.ToTable("UserBilling");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.ToTable("UserCart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserCart)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCart_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCart_User");
            });

            modelBuilder.Entity<UserWishlist>(entity =>
            {
                entity.ToTable("UserWishlist");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserWishlist)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserWishlist_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserWishlist)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserWishlist_User");
            });

            modelBuilder.Entity<UserCartModel>(entity => { });

            modelBuilder.Entity<UserWishlistModel>(entity => { });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
