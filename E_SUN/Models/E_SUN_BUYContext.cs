using System;
using System.Collections.Generic;
using E_SUN.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_SUN.Models
{
    public partial class E_SUN_BUYContext : DbContext
    {
        public E_SUN_BUYContext()
        {
        }

        public E_SUN_BUYContext(DbContextOptions<E_SUN_BUYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LikeList> LikeLists { get; set; } = null!;
        public virtual DbSet<LikeListDetail> LikeListDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<LikeListModel> LikeListModels { get; set; } = null!;
        public virtual DbSet<LikeListDetailModel> LikeListDetailModels { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=E_SUN_BUY;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LikeList>(entity =>
            {
                entity.HasKey(e => e.Sn)
                    .HasName("PK__LikeList__32151C644209FD01");

                entity.ToTable("LikeList");

                entity.Property(e => e.Sn)
                    .ValueGeneratedNever()
                    .HasColumnName("SN");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalFee).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdaeDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<LikeListDetail>(entity =>
            {
                entity.HasKey(e => e.Sn)
                    .HasName("PK__LikeList__32151C6431BD83BC");

                entity.ToTable("LikeListDetail");

                entity.Property(e => e.Sn)
                    .ValueGeneratedNever()
                    .HasColumnName("SN");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PK__Product__3214D4A86B89D8B7");

                entity.ToTable("Product");

                entity.Property(e => e.No).ValueGeneratedNever();

                entity.Property(e => e.FeeRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("UserID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.HasSequence("ListNO");

            modelBuilder.Entity<LikeListModel>().HasNoKey();
            modelBuilder.Entity<LikeListDetailModel>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
