using System;
using System.Collections.Generic;
using Demo1703251.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1703251.Context;

public partial class User11031Context : DbContext
{
    public User11031Context()
    {
    }

    public User11031Context(DbContextOptions<User11031Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsPartner> ProductsPartners { get; set; }

    public virtual DbSet<ProductsType> ProductsTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159:5432; Database=user11031; Username=user11031; Password=95350");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnersId).HasName("partners_pk");

            entity.ToTable("partners", "demo170325");

            entity.Property(e => e.PartnersId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("partners_id");
            entity.Property(e => e.PartnersAdress)
                .HasColumnType("character varying")
                .HasColumnName("partners_adress");
            entity.Property(e => e.PartnersDirectorName)
                .HasColumnType("character varying")
                .HasColumnName("partners_director_name");
            entity.Property(e => e.PartnersEmail)
                .HasColumnType("character varying")
                .HasColumnName("partners_email");
            entity.Property(e => e.PartnersName)
                .HasColumnType("character varying")
                .HasColumnName("partners_name");
            entity.Property(e => e.PartnersPhone)
                .HasColumnType("character varying")
                .HasColumnName("partners_phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductsArticul).HasName("products_pk");

            entity.ToTable("products", "demo170325");

            entity.Property(e => e.ProductsArticul)
                .HasColumnType("character varying")
                .HasColumnName("products_articul");
            entity.Property(e => e.ProductsMinCostForPartner).HasColumnName("products_min_cost_for_partner");
            entity.Property(e => e.ProductsName)
                .HasColumnType("character varying")
                .HasColumnName("products_name");
            entity.Property(e => e.ProductsType).HasColumnName("products_type");

            entity.HasOne(d => d.ProductsTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductsType)
                .HasConstraintName("products_products_type_fk");
        });

        modelBuilder.Entity<ProductsPartner>(entity =>
        {
            entity.HasKey(e => e.ProductsPartnersId).HasName("products_partners_pk");

            entity.ToTable("products_partners", "demo170325");

            entity.Property(e => e.ProductsPartnersId)
                .ValueGeneratedNever()
                .HasColumnName("products_partners_id");
            entity.Property(e => e.DateOfRealization).HasColumnName("date_of_realization");
            entity.Property(e => e.Partners).HasColumnName("partners");
            entity.Property(e => e.ProductCount).HasColumnName("product_count");
            entity.Property(e => e.Products)
                .HasColumnType("character varying")
                .HasColumnName("products");

            entity.HasOne(d => d.PartnersNavigation).WithMany(p => p.ProductsPartners)
                .HasForeignKey(d => d.Partners)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_partners_partners_fk");

            entity.HasOne(d => d.ProductsNavigation).WithMany(p => p.ProductsPartners)
                .HasForeignKey(d => d.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_partners_products_fk");
        });

        modelBuilder.Entity<ProductsType>(entity =>
        {
            entity.HasKey(e => e.ProductsTypeId).HasName("products_type_pk");

            entity.ToTable("products_type", "demo170325");

            entity.Property(e => e.ProductsTypeId)
                .ValueGeneratedNever()
                .HasColumnName("products_type_id");
            entity.Property(e => e.ProductsTypeName)
                .HasColumnType("character varying")
                .HasColumnName("products_type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
