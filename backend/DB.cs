using System;
using System.Collections.Generic;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend
{
    public partial class DB : DbContext
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<Goal> Goals { get; set; } = null!;
        public virtual DbSet<GoalPoint> GoalPoints { get; set; } = null!;
        public virtual DbSet<PointHistory> PointHistories { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamMember> TeamMembers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GoalPoint>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(100);

                entity.HasOne(d => d.GoalGu)
                    .WithMany(p => p.GoalPoints)
                    .HasForeignKey(d => d.GoalGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoalPoints_Goals");
            });

            modelBuilder.Entity<PointHistory>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.TeamGu)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.TeamGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamMembers_Teams");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
