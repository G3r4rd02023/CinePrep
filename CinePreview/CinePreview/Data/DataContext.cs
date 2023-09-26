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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>().HasIndex(c => c.Descripcion).IsUnique();
            modelBuilder.Entity<Sala>().HasIndex(c => c.NombreSala).IsUnique();
        }
    }
}
