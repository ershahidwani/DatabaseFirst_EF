using System;
using DatabaseFirst_EF.CustomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseFirst_EF.Models
{
    public partial class SAMPLEDBContext : DbContext
    {
        public SAMPLEDBContext()
        {
        }

        public SAMPLEDBContext(DbContextOptions<SAMPLEDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mark> Marks { get; set; }
       public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SAMPLEDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.Rollno)
                    .HasName("PK__MARKS__00AB72B7060DEAE8");

                entity.ToTable("MARKS");

                entity.Property(e => e.Rollno)
                    .ValueGeneratedNever()
                    .HasColumnName("ROLLNO");

                entity.Property(e => e.Totalmarks).HasColumnName("TOTALMARKS");

                entity.HasOne(d => d.RollnoNavigation)
                    .WithOne(p => p.Mark)
                    .HasForeignKey<Mark>(d => d.Rollno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MARKS_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.RollNo);

                entity.ToTable("Student");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FathersName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Parentage)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
