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

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SaleHistory> SaleHistories { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

 /*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DPC; DataBase=Count; Trusted_Connection=True; TrustServerCertificate=True");
 */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC072CE1916F");

            entity.ToTable("Client");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.PaymentAdvance)
                .HasColumnType("decimal(2, 0)")
                .HasColumnName("Payment_advance");
            entity.Property(e => e.PaymentDue)
                .HasColumnType("date")
                .HasColumnName("Payment_due");
            entity.Property(e => e.PaymentStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Payment_status");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07A7587621");

            entity.Property(e => e.AddedBy).HasColumnName("Added_by");
            entity.Property(e => e.Amount).HasDefaultValueSql("((1))");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nick)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PjoinedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Pjoined_date");
            entity.Property(e => e.Provider)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('Generic')");

            entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.AddedBy)
                .HasConstraintName("FK__Products__Added___3D5E1FD2");
        });

        modelBuilder.Entity<SaleHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale_his__3214EC071A76DC68");

            entity.ToTable("Sale_history");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCustomer).HasColumnName("Id_Customer");
            entity.Property(e => e.IdSeller).HasColumnName("Id_Seller");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.SaleHistories)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("FK__Sale_hist__Id_Cu__440B1D61");

            entity.HasOne(d => d.IdSellerNavigation).WithMany(p => p.SaleHistories)
                .HasForeignKey(d => d.IdSeller)
                .HasConstraintName("FK__Sale_hist__Id_Se__4316F928");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seller__3214EC0798EA43C0");

            entity.ToTable("Seller");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.Level).HasDefaultValueSql("((1))");
            entity.Property(e => e.NickName)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Nick_Name");
            entity.Property(e => e.Passwd)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
