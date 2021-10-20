using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Exam.Models
{
    public partial class ExamByPMhingContext : DbContext
    {
        public ExamByPMhingContext()
        {
        }

        public ExamByPMhingContext(DbContextOptions<ExamByPMhingContext> options)
            : base(options)
        {
        }

        public DbSet<tmpApplication> TmpApplications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<tmpApplication>(entity =>
            {
                entity.ToTable("tmpApplication");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
