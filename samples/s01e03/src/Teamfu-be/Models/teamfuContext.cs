using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Teamfu_be.Models
{
    public partial class teamfuContext : DbContext
    {
        public teamfuContext()
        {
        }

        public teamfuContext(DbContextOptions<teamfuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=teamfu;User Id=SA;Password=Your_secret123;");
                //Console.Out.WriteLine(this.Configuration.GetConnectionString("default"));
                //optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("lists");

                entity.Property(e => e.ListId).HasColumnName("list_id");

                entity.Property(e => e.ListName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("list_name");

                entity.Property(e => e.ListOwnerId).HasColumnName("list_owner_id");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.PercentComplete).HasColumnName("percent_complete");

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("task_description");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("task_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
