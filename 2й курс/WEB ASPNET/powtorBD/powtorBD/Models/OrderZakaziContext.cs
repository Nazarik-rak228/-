using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace powtorBD.Models;

public partial class OrderZakaziContext : DbContext
{
    public OrderZakaziContext()
    {
    }

    public OrderZakaziContext(DbContextOptions<OrderZakaziContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressCustomer> AddressCustomers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Colour> Colours { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<OrderConfiguration> OrderConfigurations { get; set; }

    public virtual DbSet<OrderZakaz> OrderZakazs { get; set; }

    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=BENITO\\SQLEXPRESS;Initial Catalog=order_zakazi;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressCustomer>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PK__address___5A7A75D91D6F6343");

            entity.ToTable("address_customer");

            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.House).HasColumnName("house");
            entity.Property(e => e.Street)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("street");

        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IdCity).HasName("PK__city__6AEC3C612A637A4B");

            entity.ToTable("city");

            entity.HasIndex(e => e.CityName, "UQ__city__1AA4F7B5664A1DC4").IsUnique();

            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Colour>(entity =>
        {
            entity.HasKey(e => e.IdColour).HasName("PK__colour__2FF83B52C59021CE");

            entity.ToTable("colour");

            entity.HasIndex(e => e.Title, "UQ__colour__E52A1BB3F5B7566D").IsUnique();

            entity.Property(e => e.IdColour).HasColumnName("id_colour");
            entity.Property(e => e.Title)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__customer__8CC9BA4679D74A2A");

            entity.ToTable("customer");

            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.NameC)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_c");


        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployees).HasName("PK__employee__822CD266F31FC1AD");

            entity.ToTable("employees");

            entity.Property(e => e.IdEmployees).HasColumnName("id_employees");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
        });

        modelBuilder.Entity<OrderConfiguration>(entity =>
        {
            entity.HasKey(e => e.IdOrderConfiguration).HasName("PK__order_co__434275ECA8C7326D");

            entity.ToTable("order_configuration");

            entity.Property(e => e.IdOrderConfiguration).HasColumnName("id_order_configuration");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdSize).HasColumnName("id_size");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("unit");


        });

        modelBuilder.Entity<OrderZakaz>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__order_za__DD5B8F3FA0627598");

            entity.ToTable("order_zakaz");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.DateOrder).HasColumnName("date_order");
            entity.Property(e => e.IdColour).HasColumnName("id_colour");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.IdEmployees).HasColumnName("id_employees");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");




        });

        modelBuilder.Entity<ProductOrder>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__product___BA39E84F2B45E4A0");

            entity.ToTable("product_order");

            entity.HasIndex(e => e.Title, "UQ__product___E52A1BB3161901DE").IsUnique();

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Title)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.IdSize).HasName("PK__size__45952BA53C793961");

            entity.ToTable("size");

            entity.HasIndex(e => e.Title, "UQ__size__E52A1BB37D59BAA7").IsUnique();

            entity.Property(e => e.IdSize).HasColumnName("id_size");
            entity.Property(e => e.Title)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__status_o__5D2DC6E8A434C5B5");

            entity.ToTable("status_order");

            entity.HasIndex(e => e.StatusName, "UQ__status_o__501B3753EFB480B6").IsUnique();

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.StatusName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
