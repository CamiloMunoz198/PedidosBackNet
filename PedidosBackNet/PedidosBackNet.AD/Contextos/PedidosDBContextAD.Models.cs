using Microsoft.EntityFrameworkCore;
using PedidosBackNet.AD.Entidades;


namespace PedidosBackNet.AD.Contextos
{
    public partial class PedidosDBContextAD :DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Almacenamiento>(entity =>
            {
                entity.HasOne(d => d.IdTipoAlmacenamientoNavigation).WithMany(p => p.Almacenamiento).HasConstraintName("FK_Almacenamiento_TipoAlmacenamiento");

                entity.HasOne(d => d.Ciudad).WithMany(p => p.Almacenamiento).HasConstraintName("FK_Almacenamiento_Ciudad");
            });

            modelBuilder.Entity<Canal>(entity =>
            {
                entity.HasOne(d => d.IdTipoCanalNavigation).WithMany(p => p.Canal).HasConstraintName("FK_Canal_TipoCanal");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasOne(d => d.CodigoDepartamentoNavigation).WithMany(p => p.Ciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Departamento");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.Cliente).HasConstraintName("FK_Cliente_TipoCliente");

                entity.HasOne(d => d.Ciudad).WithMany(p => p.Cliente).HasConstraintName("FK_Cliente_Ciudad");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasOne(d => d.IdEstatusEntregaNavigation).WithMany(p => p.Entrega).HasConstraintName("FK_Entrega_EstatusEntrega");

                entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.Entrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrega_Orden");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasOne(d => d.IdAlmacenamientoNavigation).WithMany(p => p.Inventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Almacenamiento");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Inventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Producto");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasOne(d => d.IdAlmacenamientoNavigation).WithMany(p => p.Orden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Almacenamiento");

                entity.HasOne(d => d.IdCanalNavigation).WithMany(p => p.Orden).HasConstraintName("FK_Orden_Canal");

                entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Orden).HasConstraintName("FK_Orden_Cliente");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Orden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Producto).HasConstraintName("FK_Producto_Unidades");
            });

            modelBuilder.Entity<TipoAlmacenamiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoAlmacenamiento).HasName("PK_TipoAlamcenamiento");
            });
        }
    }
}
