using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolProjektArbete.Models
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<StudClass> StudClasses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = EJPATOLITEJ;Initial Catalog=School;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassActive).HasMaxLength(50);

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmpFirstName).HasMaxLength(50);

                entity.Property(e => e.EmpLastName).HasMaxLength(50);

                entity.Property(e => e.EmpPosition).HasMaxLength(50);

                entity.Property(e => e.StartingYear).HasColumnType("date");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.GradesId);

                entity.Property(e => e.GradesId).HasColumnName("GradesID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GclassId).HasColumnName("GClassID");

                entity.Property(e => e.GempId).HasColumnName("GEmpID");

                entity.Property(e => e.Grade1).HasColumnName("Grade");

                entity.Property(e => e.GstudId).HasColumnName("GStudID");

                entity.HasOne(d => d.Gclass)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.GclassId)
                    .HasConstraintName("FK_Grades_Class");

                entity.HasOne(d => d.Gemp)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.GempId)
                    .HasConstraintName("FK_Grades_Employee");

                entity.HasOne(d => d.Gstud)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.GstudId)
                    .HasConstraintName("FK_Grades_Student");
            });

            modelBuilder.Entity<StudClass>(entity =>
            {
                entity.ToTable("StudClass");

                entity.Property(e => e.StudClassId).HasColumnName("StudClassID");

                entity.Property(e => e.FkClassId).HasColumnName("fkClassID");

                entity.Property(e => e.FkStudId).HasColumnName("fkStudID");

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.StudClasses)
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_StudClass_Class");

                entity.HasOne(d => d.FkStud)
                    .WithMany(p => p.StudClasses)
                    .HasForeignKey(d => d.FkStudId)
                    .HasConstraintName("FK_StudClass_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(50)
                    .HasColumnName("SSN");

                entity.Property(e => e.StudFirstName).HasMaxLength(50);

                entity.Property(e => e.StudLastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
