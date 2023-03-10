using System;
using System.Collections.Generic;
using Google.Cloud.EntityFrameworkCore.Spanner.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace my_first_spanner_connector.entitymodel
{
    public partial class SampleContext : DbContext
    {
        public SampleContext()
        {
        }

        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<student_details> student_details { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSpanner("Name=ConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<student_details>(entity =>
            {
                entity.HasKey(e => e.rollnumber)
                    .HasName("PRIMARY_KEY");

                entity.Property(e => e.rollnumber).ValueGeneratedNever();

                entity.Property(e => e.department).HasMaxLength(50);

                entity.Property(e => e.grade).HasMaxLength(2);

                entity.Property(e => e.student_name).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
