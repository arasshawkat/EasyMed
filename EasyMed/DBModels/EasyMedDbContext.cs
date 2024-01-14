using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EasyMed.DBModels;

public partial class EasyMedDbContext : DbContext
{
    public EasyMedDbContext()
    {
    }

    public EasyMedDbContext(DbContextOptions<EasyMedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoctorTbl> DoctorTbls { get; set; }

    public virtual DbSet<HospitalTbl> HospitalTbls { get; set; }

    public virtual DbSet<PatientTbl> PatientTbls { get; set; }

    public virtual DbSet<RoleTbl> RoleTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EasyMedDB;Encrypt=false;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorTbl>(entity =>
        {
            entity.ToTable("DoctorTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DoctorDeg).HasMaxLength(50);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.DoctorSpe).HasMaxLength(50);
        });

        modelBuilder.Entity<HospitalTbl>(entity =>
        {
            entity.ToTable("HospitalTbl");

            entity.Property(e => e.HospitalName).HasMaxLength(50);
            entity.Property(e => e.IsVisible).HasColumnName("isVisible");
        });

        modelBuilder.Entity<PatientTbl>(entity =>
        {
            entity.ToTable("PatientTbl");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BloodGroup).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.PatientCode).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleTbl>(entity =>
        {
            entity.ToTable("RoleTbl");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.ToTable("UserTbl");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.DisplayName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
