﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class ProyectoContext : DbContext
{
    public ProyectoContext()
    {
    }

    public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<sp_GetAllEmpleados_Result> Sp_GetAllEmpleados_Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WillTower;Database=PROYECTO;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE87E373E5");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroTelefonico).HasMaxLength(20);
            entity.Property(e => e.SegundoApellido).HasMaxLength(50);
            entity.Property(e => e.Contrasena).HasMaxLength(64);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__5295297C940FE957");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroTelefonico).HasMaxLength(20);
            entity.Property(e => e.SegundoApellido).HasMaxLength(50);
            entity.Property(e => e.Contrasena).HasMaxLength(50);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132A8F6D1AA");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.Imagen).HasColumnType("varbinary(MAX)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasMaxLength(20);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB9811974BB9210");

            entity.ToTable("Servicio");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.Imagen).HasColumnType("varbinary(MAX)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasMaxLength(20);
        });

        modelBuilder.Entity<Piscina>(entity =>
        {
            entity.HasKey(e => e.PiscinaId).HasName("PK__Piscina__CEB9811974BB9210");
            entity.ToTable("Piscina"); // Nombre de la tabla en la base de datos

            entity.Property(e => e.PiscinaId).HasColumnName("PiscinaId");
            entity.Property(e => e.Nombre).HasMaxLength(100); // Ejemplo de configuración de propiedad
            entity.Property(e => e.Imagen).HasColumnType("varbinary(MAX)"); // Para almacenar imágenes en SQL Server
            entity.Property(e => e.Comentario).HasMaxLength(500); // Longitud máxima del comentario
            entity.Property(e => e.EmpleadoComentario).HasMaxLength(100); // Longitud máxima del empleado comentario

            entity.HasOne(e => e.Cliente) // Relación con Cliente
                .WithMany() // Uno a muchos
                .HasForeignKey(e => e.ClienteId) // Clave foránea
                .IsRequired(); // Requerido

            entity.HasOne(e => e.Servicio) // Relación con Servicio
                .WithMany() // Uno a muchos
                .HasForeignKey(e => e.ServicioId); // Clave foránea (opcional)

            // Restricciones de la base de datos adicionales o configuraciones de índices pueden agregarse aquí
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
