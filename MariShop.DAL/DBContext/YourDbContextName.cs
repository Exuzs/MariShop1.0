using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MariShop.Model.Models;

namespace MariShop.DAL.DBContext;

public partial class YourDbContextName : DbContext
{
    public YourDbContextName()
    {
    }

    public YourDbContextName(DbContextOptions<YourDbContextName> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Detallespedido> Detallespedidos { get; set; }

    public virtual DbSet<Direccionesenvio> Direccionesenvios { get; set; }

    public virtual DbSet<Envios> Envios { get; set; }

    public virtual DbSet<Estadosenvio> Estadosenvios { get; set; }

    public virtual DbSet<Metodospago> Metodospagos { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Transaccionespago> Transaccionespagos { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Variantesproducto> Variantesproductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Detallespedido>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PRIMARY");

            entity.ToTable("detallespedido");

            entity.HasIndex(e => e.ProductoId, "ProductoID");

            entity.HasIndex(e => e.VarianteId, "VarianteID");

            entity.HasIndex(e => e.PedidoId, "idx_detallespedido_pedido");

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.Precio).HasPrecision(10);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.VarianteId).HasColumnName("VarianteID");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("detallespedido_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("detallespedido_ibfk_2");

            entity.HasOne(d => d.Variante).WithMany(p => p.Detallespedidos)
                .HasForeignKey(d => d.VarianteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("detallespedido_ibfk_3");
        });

        modelBuilder.Entity<Direccionesenvio>(entity =>
        {
            entity.HasKey(e => e.DireccionEnvioId).HasName("PRIMARY");

            entity.ToTable("direccionesenvio");

            entity.HasIndex(e => e.UserId, "UserID");

            entity.Property(e => e.DireccionEnvioId).HasColumnName("DireccionEnvioID");
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasColumnType("text");
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Direccionesenvios)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("direccionesenvio_ibfk_1");
        });

        modelBuilder.Entity<Envios>(entity =>
        {
            entity.HasKey(e => e.EnvioId).HasName("PRIMARY");

            entity.ToTable("envios");

            entity.HasIndex(e => e.DireccionEnvioId, "DireccionEnvioID");

            entity.HasIndex(e => e.EstadoEnvioId, "EstadoEnvioID");

            entity.HasIndex(e => e.PedidoId, "idx_envios_pedido");

            entity.Property(e => e.EnvioId).HasColumnName("EnvioID");
            entity.Property(e => e.DireccionEnvioId).HasColumnName("DireccionEnvioID");
            entity.Property(e => e.EstadoEnvioId).HasColumnName("EstadoEnvioID");
            entity.Property(e => e.FechaEntrega).HasColumnType("timestamp");
            entity.Property(e => e.FechaEnvio).HasColumnType("timestamp");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

            entity.HasOne(d => d.DireccionEnvio).WithMany(p => p.Envios)
                .HasForeignKey(d => d.DireccionEnvioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("envios_ibfk_2");

            entity.HasOne(d => d.EstadoEnvio).WithMany(p => p.Envios)
                .HasForeignKey(d => d.EstadoEnvioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("envios_ibfk_3");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Envios)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("envios_ibfk_1");
        });

        modelBuilder.Entity<Estadosenvio>(entity =>
        {
            entity.HasKey(e => e.EstadoEnvioId).HasName("PRIMARY");

            entity.ToTable("estadosenvio");

            entity.Property(e => e.EstadoEnvioId).HasColumnName("EstadoEnvioID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Metodospago>(entity =>
        {
            entity.HasKey(e => e.MetodoPagoId).HasName("PRIMARY");

            entity.ToTable("metodospago");

            entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PRIMARY");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.UserId, "idx_pedidos_usuario");

            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Total).HasPrecision(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.CategoriaId, "idx_productos_categoria");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ImagenUrl)
                .HasColumnType("text")
                .HasColumnName("ImagenURL");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10);
            entity.Property(e => e.Stock).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Transaccionespago>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("PRIMARY");

            entity.ToTable("transaccionespago");

            entity.HasIndex(e => e.MetodoPagoId, "MetodoPagoID");

            entity.HasIndex(e => e.PayPalTransactionId, "PayPalTransactionID").IsUnique();

            entity.HasIndex(e => e.PedidoId, "PedidoID");

            entity.Property(e => e.TransaccionId).HasColumnName("TransaccionID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.MetodoPagoId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("MetodoPagoID");
            entity.Property(e => e.Monto).HasPrecision(10);
            entity.Property(e => e.PayPalTransactionId).HasColumnName("PayPalTransactionID");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Transaccionespagos)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("transaccionespago_ibfk_2");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Transaccionespagos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("transaccionespago_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Direccion).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.UltimoAcceso).HasColumnType("timestamp");

            entity.HasMany(d => d.Rols).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Usuariosrole",
                    r => r.HasOne<Roles>().WithMany()
                        .HasForeignKey("RolId")
                        .HasConstraintName("usuariosroles_ibfk_2"),
                    l => l.HasOne<Usuarios>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("usuariosroles_ibfk_1"),
                    j =>
                    {
                        j.HasKey("UserId", "RolId").HasName("PRIMARY");
                        j.ToTable("usuariosroles");
                        j.HasIndex(new[] { "RolId" }, "RolID");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RolId").HasColumnName("RolID");
                    });
        });

        modelBuilder.Entity<Variantesproducto>(entity =>
        {
            entity.HasKey(e => e.VarianteId).HasName("PRIMARY");

            entity.ToTable("variantesproducto");

            entity.HasIndex(e => e.ProductoId, "ProductoID");

            entity.Property(e => e.VarianteId).HasColumnName("VarianteID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioAdicional)
                .HasPrecision(10)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Stock).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.Producto).WithMany(p => p.Variantesproductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("variantesproducto_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
