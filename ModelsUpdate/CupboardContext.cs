﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public partial class CupboardContext : IdentityDbContext<Users>
    {
        public CupboardContext(DbContextOptions<CupboardContext> options)
            : base(options)
        {
        }

        public  DbSet<CategoriesXproduct> CategoriesXproducts { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<CupBoard> CupBoards { get; set; }
        public  DbSet<CupBoardDetail> CupBoardDetail { get; set; } 
        public  DbSet<Product> Products { get; set; }
        public  DbSet<ShoppingList> ShoppingLists { get; set; }
        public  DbSet<Trademark> Trademarks { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<UserXcupBoard> UserXcupBoards { get; set; }
        public  DbSet<UserXshoppingList> UserXshoppingLists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CategoriesXproduct>(entity =>
            {
                entity.HasKey(e => e.IdCategoryXproduct)
                    .HasName("PK__Categori__E775EBF5BECA41C4");

                entity.Property(e => e.IdCategoryXproduct).IsUnicode(false);

                entity.Property(e => e.IdCategory).IsUnicode(false);

                entity.Property(e => e.IdProduct).IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.CategoriesXproducts)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_Category_CategoryXProduct");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.CategoriesXproducts)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Product_CategoryXProduct");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.IdCategory).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<CupBoard>(entity =>
            {
                entity.HasKey(e => e.IdCupBoard)
                    .HasName("PK__CupBoard__089DCDC596B81653");

                entity.Property(e => e.IdCupBoard);

                entity.Property(e => e.NameCupBoard);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CupBoardDetail>(entity =>
            {
                entity.ToTable("CupBoardDetail");

                entity.HasKey(e => e.IdCupboardDetail)
                    .HasName("PK__CupBoard__45BC4B6ADE04BAA2");

                entity.Property(e => e.IdCupboardDetail).HasColumnName("idCupboardDetail");

                entity.Property(e => e.IdCupBoard).HasColumnName("idCupBoard");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.ExitDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.HasOne(d => d.CupBoard)
                    .WithMany(p => p.CupBoardDetails)
                    .HasForeignKey(d => d.IdCupBoard)
                    .HasConstraintName("FK_CupBoard_Detail");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CupBoardDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_CupBoard_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__5EEC79D120FD1CAC");

                entity.Property(e => e.IdProduct).IsUnicode(false);

                entity.Property(e => e.IdMark).IsUnicode(false);

                entity.Property(e => e.NameProduct).IsUnicode(false);

                entity.Property(e => e.BarCode).IsUnicode(false);

                entity.HasOne(d => d.Trademark)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdMark)
                .HasConstraintName("FK_Mark_Products")
                ;
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.HasKey(e => e.IdShopping)
                    .HasName("PK__Shopping__957AB8FE0BB0BFD7");

                entity.Property(e => e.IdShopping).IsUnicode(false);

                entity.Property(e => e.IdProduct).IsUnicode(false);

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ShoppingLists)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_User_Shopping");
            });

            modelBuilder.Entity<Trademark>(entity =>
            {
                entity.HasKey(e => e.IdTrademark)
                    .HasName("PK__Trademar__7C4427A36D95025C");

                entity.Property(e => e.IdTrademark).IsUnicode(false);

                entity.Property(e => e.Mark).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__3717C982E1EBA768");

                entity.Property(e => e.IdUser).IsUnicode(false);
            });

            modelBuilder.Entity<UserXcupBoard>(entity =>
            {
                entity.HasKey(e => e.IdUserXcupboard)
                    .HasName("PK__UserXCup__D653D90B6AEE5AA5");

                entity.Property(e => e.IdUserXcupboard).IsUnicode(false);

                entity.Property(e => e.IdCupBoard).IsUnicode(false);

                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.HasOne(d => d.IdCupBoardNavigation)
                    .WithMany(p => p.UserXcupBoards)
                    .HasForeignKey(d => d.IdCupBoard)
                    .HasConstraintName("FK_CupBoard_UserCupBoard");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserXcupBoards)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_User_CupBoard");
            });

            modelBuilder.Entity<UserXshoppingList>(entity =>
            {
                entity.HasKey(e => e.IdUserXshopping)
                    .HasName("PK__UserXSho__3DDAB8017C0E8680");

                entity.Property(e => e.IdUserXshopping).IsUnicode(false);

                entity.Property(e => e.IdShopping).IsUnicode(false);

                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.HasOne(d => d.IdShoppingNavigation)
                    .WithMany(p => p.UserXshoppingLists)
                    .HasForeignKey(d => d.IdShopping)
                    .HasConstraintName("FK_Shopping_UserXShopping");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserXshoppingLists)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_User_UserXShopping");
            });

            modelBuilder.Entity<CategoriesXproduct>().Property(e => e.IdCategoryXproduct).HasConversion<string>();
            modelBuilder.Entity<Category>().Property(e => e.IdCategory).HasConversion<string>();
            modelBuilder.Entity<CupBoard>().Property(e => e.IdCupBoard).HasConversion<string>();
            modelBuilder.Entity<CupBoardDetail>().Property(e => e.IdCupboardDetail).HasConversion<string>();
            modelBuilder.Entity<Product>().Property(e => e.IdProduct).HasConversion<string>();
            modelBuilder.Entity<ShoppingList>().Property(e => e.IdShopping).HasConversion<string>();
            modelBuilder.Entity<Trademark>().Property(e => e.IdTrademark).HasConversion<string>();
            modelBuilder.Entity<User>().Property(e => e.IdUser).HasConversion<string>();
            modelBuilder.Entity<UserXcupBoard>().Property(e => e.IdUserXcupboard).HasConversion<string>();
            modelBuilder.Entity<UserXshoppingList>().Property(e => e.IdUserXshopping).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
