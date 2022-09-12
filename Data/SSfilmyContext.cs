using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SSfilmyModels.Models;

namespace SSfilmyData.Data
{
    public partial class SSfilmyContext : DbContext
    {
        public SSfilmyContext()
        {
        }

        public SSfilmyContext(DbContextOptions<SSfilmyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.HasIndex(e => e.Title, "movies_title_key")
                    .IsUnique();

                entity.HasIndex(e => e.Title, "movies_title_key1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Director)
                    .HasMaxLength(20)
                    .HasColumnName("director")
                    .HasDefaultValueSql("'unknown'::character varying");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasDefaultValueSql("0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
