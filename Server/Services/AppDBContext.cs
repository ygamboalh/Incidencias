using Incidencias.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Incidencias.Server.Services
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<DiaTrabajo> DiaTrabajos { get; set; }
        public DbSet<Ocurrencia> Ocurrencias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoOcurrencia> TipoOcurrencias { get; set; }
    }
}
