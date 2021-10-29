using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiProductManagment.Models
{
    public partial class ProductsManagmentContext : DbContext
    {
        public ProductsManagmentContext()
        {
        }

        public ProductsManagmentContext(DbContextOptions<ProductsManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cupboard> Cupboards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MNB294\\SQLEXPRESS; Database=ProductsManagment; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand)
                    .HasName("PK__Brand__662A665979D6452A");

                entity.Property(e => e.IdBrand).ValueGeneratedNever();

                entity.Property(e => e.BrandName).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).IsUnicode(false);

                entity.Property(e => e.Perishable).HasDefaultValueSql("((0))");

                entity.Property(e => e.Refrigerated).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sku).IsUnicode(false);

                entity.HasOne(d => d.IdProductCtNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdProductCt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category__IdProd__4316F928");
            });

            modelBuilder.Entity<Cupboard>(entity =>
            {
                entity.HasKey(e => e.IdCupboard)
                    .HasName("PK__Cupboard__D3FBAD618C22A46F");

                entity.Property(e => e.SectiontName).IsUnicode(false);

                entity.HasOne(d => d.IdProductCbNavigation)
                    .WithMany(p => p.Cupboards)
                    .HasForeignKey(d => d.IdProductCb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cupboard__IdProd__46E78A0C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__2E8946D40FB74B58");

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Sku).IsUnicode(false);
            });

            modelBuilder.Entity<ProductBrand>(entity =>
            {
                entity.HasOne(d => d.IdBrandPbNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBrandPb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_B__IdBra__3C69FB99");

                entity.HasOne(d => d.IdProductPbNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProductPb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_B__IdPro__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
