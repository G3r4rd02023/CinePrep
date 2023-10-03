using CinePreview.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CinePreview.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>().HasIndex(c => c.Descripcion).IsUnique();
            modelBuilder.Entity<Asiento>().HasIndex(c => c.NumeroAsiento).IsUnique();
            modelBuilder.Entity<Sala>().HasIndex(c => c.NombreSala).IsUnique();
        }
    }
}
