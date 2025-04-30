using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Models;

public partial class ShumkovaMasterContext : DbContext
{
    public ShumkovaMasterContext()
    {
    }

    public ShumkovaMasterContext(DbContextOptions<ShumkovaMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MYCOMPUTER\\SQLEXPRESS;Database=ShumkovaMaster;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("MaterialType");

            entity.Property(e => e.Name).HasColumnType("ntext");
            entity.Property(e => e.ProcentBrakMaterial).HasColumnType("ntext");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.Property(e => e.Director).HasColumnType("ntext");
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .HasColumnName("INN");
            entity.Property(e => e.Mail).HasColumnType("ntext");
            entity.Property(e => e.Name).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasColumnType("ntext");
            entity.Property(e => e.Rating).HasMaxLength(50);
            entity.Property(e => e.TypePartner).HasColumnType("ntext");
            entity.Property(e => e.UrAdress).HasColumnType("ntext");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasOne(d => d.Partners).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartnerProducts_Partners");

            entity.HasOne(d => d.Products).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartnerProducts_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.MinPrice).HasColumnType("money");
            entity.Property(e => e.Name).HasColumnType("ntext");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Name).HasColumnType("ntext");
            entity.Property(e => e.QtypeProduct).HasColumnName("QTypeProduct");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
