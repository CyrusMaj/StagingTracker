using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StagingTracker.Data;

public partial class StagingTrackerDbContext : DbContext
{
    public StagingTrackerDbContext(DbContextOptions<StagingTrackerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Dispatching> Dispatchings { get; set; }

    public virtual DbSet<OrderManagement> OrderManagements { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<QualityControl> QualityControls { get; set; }

    public virtual DbSet<Receiving> Receivings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B875CB28DF");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dispatching>(entity =>
        {
            entity.HasKey(e => e.DispatchId).HasName("PK__Dispatch__434DBD7592EA371E");

            entity.ToTable("Dispatching");

            entity.Property(e => e.DispatchId).HasColumnName("DispatchID");
            entity.Property(e => e.CarrierId).HasColumnName("CarrierID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.Dispatchings)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Dispatchi__Order__3E52440B");

            entity.HasOne(d => d.Product).WithMany(p => p.Dispatchings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Dispatchi__Produ__3F466844");
        });

        modelBuilder.Entity<OrderManagement>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderMan__C3905BAFC73F2FC9");

            entity.ToTable("OrderManagement");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderManagements)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_OrderManagement_Customers");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED4CFB2C08");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<QualityControl>(entity =>
        {
            entity.HasKey(e => e.Qcid).HasName("PK__QualityC__DC29BF922680BBF8");

            entity.ToTable("QualityControl");

            entity.Property(e => e.Qcid).HasColumnName("QCID");
            entity.Property(e => e.InspectionResult)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InspectorName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReceivingId).HasColumnName("ReceivingID");

            entity.HasOne(d => d.Receiving).WithMany(p => p.QualityControls)
                .HasForeignKey(d => d.ReceivingId)
                .HasConstraintName("FK__QualityCo__Recei__4222D4EF");
        });

        modelBuilder.Entity<Receiving>(entity =>
        {
            entity.HasKey(e => e.ReceivingId).HasName("PK__Receivin__9D0E87BC1D4C6AA8");

            entity.ToTable("Receiving");

            entity.Property(e => e.ReceivingId).HasColumnName("ReceivingID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Product).WithMany(p => p.Receivings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Receiving__Produ__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
