using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace NV.Models;

public partial class CountContext : DbContext
{
    public CountContext()
    {
    }

    public CountContext(DbContextOptions<CountContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SaleLog> SaleLogs { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=DPC; DataBase=Count; Trusted_Connection=True; TrustServerCertificate=True");
     */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0709595160");

            entity.ToTable("Customer");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("_name");

            entity.HasOne(d => d.SellerNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Seller)
                .HasConstraintName("FK__Customer__Seller__5070F446");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07C30BC568");

            entity.Property(e => e.Amount)
                .HasDefaultValueSql("((1))")
                .HasColumnName("amount");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("_name");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.SellerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Seller)
                .HasConstraintName("FK__Products__Seller__4F7CD00D");
        });

        modelBuilder.Entity<SaleLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SaleLog__3213E83F13BD9AAC");

            entity.ToTable("SaleLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Customer).HasColumnName("customer");
            entity.Property(e => e.Saledetail).HasColumnName("saledetail");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.SaleLogs)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("FK__SaleLog__custome__534D60F1");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seller__3214EC0703A13E81");

            entity.ToTable("Seller");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("_name");
            entity.Property(e => e.Passwd)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("passwd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
