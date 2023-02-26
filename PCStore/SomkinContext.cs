using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PCStore;

public partial class SomkinContext : DbContext
{
    public SomkinContext()
    {
    }

    public SomkinContext(DbContextOptions<SomkinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemSpec> ItemSpecs { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Somkin; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemSpec)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemSpec>(entity =>
        {
            entity.ToTable("ItemSpec");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cores)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Frequency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.MemCapacity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Power)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Item).WithMany(p => p.ItemSpecs)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ItemSpec_Item");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.ToTable("ItemType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Manufacture)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Item).WithMany(p => p.ItemTypes)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ItemType_Item");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Delivery)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsersId).HasColumnName("UsersID");

            entity.HasOne(d => d.Item).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_Store_Item");

            entity.HasOne(d => d.Users).WithMany(p => p.Stores)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_Store_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrdersId).HasColumnName("OrdersID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Orders).WithMany(p => p.Users)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK_Users_Orders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
