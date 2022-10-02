﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyForum.Data.MyForum
{
    public partial class ForumContext : DbContext
    {
        public ForumContext()
        {
        }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Comments__C1FFD861D6172FE6");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__Pid__3B75D760");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Posts__C570593895F8F4EE");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}