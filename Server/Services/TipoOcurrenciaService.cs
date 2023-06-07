using Incidencias.Server.Services.Interfaces;
using Incidencias.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Incidencias.Server.Services
{
    public class TipoOcurrenciaService : ITipoOcurrenciaService
    {
        private readonly AppDBContext _appDBContext;
        public TipoOcurrenciaService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public void AgregarTipoOcurrencia<T>(T entity) where T : class
        {
            _appDBContext.Add(entity);
        }

        public void EliminarTipoOcurrencia<T>(T entity) where T : class
        {
            _appDBContext.Remove(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<TipoOcurrencia> ObtenerTipoOcurrenciaPorIdAsync(int id)
        {
            var tipoOcurrencia = await _appDBContext.TipoOcurrencias.FirstOrDefaultAsync(x => x.Id == id);
            return tipoOcurrencia;
        }

        public async Task<List<TipoOcurrencia>> ObtenerTiposOcurrenciasAsync()
        {
            var tipoOcurrencias = await _appDBContext.TipoOcurrencias.ToListAsync();
            return tipoOcurrencias;
        }

        public async Task<bool> SalvarCambios()
        {
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}
