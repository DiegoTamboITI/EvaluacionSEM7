using Microsoft.EntityFrameworkCore;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Coordinador> coordinadors { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Tecnico> tecnicos { get; set; }
        public DbSet<Oficina> oficinas { get; set; }
        public DbSet<ActaEntrega> actasentregas { get; set; }
        public DbSet<Computador> computadores { get; set; }
        public DbSet<Contrato> contratos { get; set; }
        public DbSet<HistorialAdministrador> historialadministradores { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coordinador>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Tecnico>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<Oficina>().HasIndex(x => x.NombreOficina).IsUnique();
            modelBuilder.Entity<ActaEntrega>().HasIndex(x => x.FechaEntrega).IsUnique();
            modelBuilder.Entity<Computador>().HasIndex(x => x.Modelo).IsUnique();
            modelBuilder.Entity<Contrato>().HasIndex(x => x.NumeroContrato).IsUnique();
            modelBuilder.Entity<HistorialAdministrador>().HasIndex(x => x.FechaInicio).IsUnique();
            modelBuilder.Entity<OrdenCompra>().HasIndex(x => x.NumeroCompra).IsUnique();
            
            // Definicion de relaciones

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.oficinas)
                .WithMany(o => o.usuarios)
                .HasForeignKey(u => u.OficinaId);

           modelBuilder.Entity<ActaEntrega>()
               .HasOne(a => a.usuarios)
               .WithMany(u => u.actasentregas)
               .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<ActaEntrega>()
                .HasOne(a => a.tecnicos)
                .WithMany(t => t.actasentregas)
                .HasForeignKey(a =>a.UsuarioId);

            modelBuilder.Entity<ActaEntrega>()
                .HasOne(a => a.oficinas)
                .WithMany(o => o.actasentregas)
                .HasForeignKey(a => a.OficinaId);

            modelBuilder.Entity<ActaEntrega>()
                .HasOne(a => a.computadores)
                .WithMany(c => c.actasentregas)
                .HasForeignKey(a => a.ComputadorId);

            modelBuilder.Entity<Computador>()
                .HasOne(c => c.ordencompras)
                .WithMany(o => o.computadores)
                .HasForeignKey(c => c.OrdenCompraId);

            modelBuilder.Entity<Computador>()
                .HasOne(c => c.contratos)
                .WithMany(co => co.computadores)
                .HasForeignKey(c => c.ContratoId);

            modelBuilder.Entity<HistorialAdministrador>()
                .HasOne(h => h.tecnicos)
                .WithMany(t => t.historialadministradores)
                .HasForeignKey(h => h.TecnicoId);
        }
    }
}
