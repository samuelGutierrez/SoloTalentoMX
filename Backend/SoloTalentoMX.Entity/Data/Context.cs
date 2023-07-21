using Microsoft.EntityFrameworkCore;
using SoloTalentoMX.Data.Domain;

namespace SoloTalentoMX.Entity.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Administradores> Administradores { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<ArticuloTienda> ArticuloTienda { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulo { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Tiendas> Tiendas { get; set; }
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
