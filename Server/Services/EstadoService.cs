using Incidencias.Server.Services.Interfaces;
using Incidencias.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Incidencias.Server.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly AppDBContext _appDBContext;

        public EstadoService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public void AgregarEstado<T>(T entity) where T : class
        {
            _appDBContext.Add(entity);
        }

        public void EliminarEstado<T>(T entity) where T : class
        {
            _appDBContext.Remove(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<Estado> ObtenerEstadoPorIdAsync(int id)
        {
            var estado = await _appDBContext.Estados.FirstOrDefaultAsync(x => x.Id == id);
            return estado;
        }

        public async Task<List<Estado>> ObtenerEstadosAsync()
        {
            var estados = await _appDBContext.Estados.ToListAsync();
            return estados;
        }

        public async Task<bool> SalvarCambios()
        {
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}
