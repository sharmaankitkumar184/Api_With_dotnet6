using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_With_dotnet6.Models
{
    public partial class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL5110.site4now.net;Initial Catalog=db_a98068_masterdatabase;User Id=db_a98068_masterdatabase_admin;Password=Master@185;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.AssetType)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("asset_type");

                entity.Property(e => e.AuthorAvatar)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("author_avatar");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("author_name");

                entity.Property(e => e.Blogtitle)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("blogtitle");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(155)
                    .IsUnicode(false)
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(455)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.ThumbnailText)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("thumbnail_text");

                entity.Property(e => e.UpdatedAt)
                    .HasMaxLength(155)
                    .IsUnicode(false)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
