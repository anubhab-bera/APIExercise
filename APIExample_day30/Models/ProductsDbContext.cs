using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIExample_day30.Models;

public partial class ProductsDbContext : DbContext
{
    public ProductsDbContext()
    {
    }

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Companyinfo> Companyinfos { get; set; }

    public virtual DbSet<Productinfo> Productinfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-MFEN465;database=ProductsDb;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Companyinfo>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Companyi__C1F8DC3933B6DFD7");

            entity.ToTable("Companyinfo");

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("CId");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .HasColumnName("CName");
        });

        modelBuilder.Entity<Productinfo>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Producti__C5775540706D56F6");

            entity.ToTable("Productinfo");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("PId");
            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.Pmdate)
                .HasColumnType("datetime")
                .HasColumnName("PMDate");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("PName");
            entity.Property(e => e.Pprice).HasColumnName("PPrice");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Productinfos)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__Productinfo__CId__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
