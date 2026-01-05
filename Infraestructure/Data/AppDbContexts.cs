using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<ComercioRef> Comercios { get; set; }
        public DbSet<RepartidorRef> Repartidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CONFIGURACIÓN DE PEDIDO
            modelBuilder.Entity<Pedido>(entity =>
            {
                // Precisión de decimales para dinero
                entity.Property(p => p.CostoEnvio).HasColumnType("decimal(18,2)");
                entity.Property(p => p.TotalProductos).HasColumnType("decimal(18,2)");

                // Configuración de UBICACIÓN ORIGEN (Se guarda en la misma tabla Pedidos)
                entity.OwnsOne(p => p.UbicacionOrigen, nav =>
                {
                    nav.Property(u => u.Latitud).HasColumnName("Origen_Latitud");
                    nav.Property(u => u.Longitud).HasColumnName("Origen_Longitud");
                    nav.Property(u => u.DireccionTexto).HasColumnName("Origen_Direccion").HasMaxLength(200);
                    nav.Property(u => u.Referencia).HasColumnName("Origen_Referencia").HasMaxLength(200);
                });

                // Configuración de UBICACIÓN DESTINO
                entity.OwnsOne(p => p.UbicacionDestino, nav =>
                {
                    nav.Property(u => u.Latitud).HasColumnName("Destino_Latitud");
                    nav.Property(u => u.Longitud).HasColumnName("Destino_Longitud");
                    nav.Property(u => u.DireccionTexto).HasColumnName("Destino_Direccion").HasMaxLength(200);
                    nav.Property(u => u.Referencia).HasColumnName("Destino_Referencia").HasMaxLength(200);
                });

                // Relaciones Opcionales
                entity.HasOne(p => p.Comercio)
                      .WithMany(c => c.Pedidos)
                      .HasForeignKey(p => p.IdComercio)
                      .IsRequired(false); // Puede ser nulo (Envío de paquetes)

                entity.HasOne(p => p.Repartidor)
                      .WithMany(r => r.Pedidos)
                      .HasForeignKey(p => p.IdRepartidor)
                      .IsRequired(false); // Puede ser nulo (Al inicio)
            });

            // CONFIGURACIÓN DE COMERCIO
            modelBuilder.Entity<ComercioRef>(entity =>
            {
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);

                // Configuración de la ubicación del Local
                entity.OwnsOne(c => c.UbicacionLocal, nav =>
                {
                    nav.Property(u => u.Latitud).HasColumnName("Local_Latitud");
                    nav.Property(u => u.Longitud).HasColumnName("Local_Longitud");
                    nav.Property(u => u.DireccionTexto).HasColumnName("Local_Direccion").HasMaxLength(200);
                    nav.Property(u => u.Referencia).HasColumnName("Local_Referencia").HasMaxLength(200);
                });
            });
        }
    }
}
