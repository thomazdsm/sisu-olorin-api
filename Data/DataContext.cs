using Microsoft.EntityFrameworkCore;
using sisu_olorin_api.Models.Usuarios;

namespace sisu_olorin_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
    }
}
