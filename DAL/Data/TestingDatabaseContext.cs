using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Data
{
    public partial class TestingDatabaseContext : DbContext
    {
        //public TestingDatabaseContext()
        //{
        //}

        public TestingDatabaseContext(DbContextOptions<TestingDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; database=TestingDatabase;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.ToTable("Show");

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImdbId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poster)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Show_Profile");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
