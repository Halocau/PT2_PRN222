using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuiTienQuat_SE1814_NET_PT2.Models;

public partial class Pt2prn222Context : DbContext
{
    public Pt2prn222Context()
    {
    }

    public Pt2prn222Context(DbContextOptions<Pt2prn222Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("server =(local); database =PT2PRN222; uid=sa;pwd=123;Encrypt=false");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Major).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
