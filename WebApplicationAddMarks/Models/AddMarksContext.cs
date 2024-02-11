using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationAddMarks.Models
{
    public partial class AddMarksContext : DbContext
    {
        public AddMarksContext()
        {
        }

        public AddMarksContext(DbContextOptions<AddMarksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Marks> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=RASHMIPRIYA;database=AddMarks;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marks>(entity =>
            {
                entity.Property(e => e.MarkId).ValueGeneratedNever();

                entity.Property(e => e.Mark).HasColumnName("Mark");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Marks__StudentId__5BE2A6F2");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Marks__SubjectId__5CD6CB2B");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName }, "UQ_Students_FullName")
                    .IsUnique();

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.SubjectName, "UQ_Subjects_SubjectName")
                    .IsUnique();

                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
