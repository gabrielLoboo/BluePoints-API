using BluePoints_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BluePoints_API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Premio> Premios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPremio> UsuarioPremios { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("Data Source=oracle.fiap.com.br:1521/orcl;User ID=rm99708;Password=180105");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioPremio>()
                .HasKey(up => new { up.UsuarioId, up.PremioId });

            modelBuilder.Entity<Premio>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Premios)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<UsuarioPremio>()
                .HasOne(up => up.Usuario)
                .WithMany(u => u.UsuarioPremios)
                .HasForeignKey(up => up.UsuarioId);

            modelBuilder.Entity<UsuarioPremio>()
                .HasOne(up => up.Premio)
                .WithMany(p => p.UsuarioPremios)
                .HasForeignKey(up => up.PremioId);
        }
        public DbSet<BluePoints_API.Models.Categoria> Categoria { get; set; } = default!;
    }
}

