using Incidencias.Server.Services.Interfaces;
using Incidencias.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Incidencias.Server.Services
{
    public class OcurrenciaService : IOcurrenciaService
    {
        private readonly AppDBContext _appDBContext;
        public OcurrenciaService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public void AgregarOcurrencia<T>(T entity) where T : class
        {
            _appDBContext.Add(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<Ocurrencia> EditarOcurrenciaAsync(Ocurrencia ocurrencia)
        {
            _appDBContext.Ocurrencias.Where(x => x.Id == ocurrencia.Id)
                        .ExecuteUpdate(setters => setters.SetProperty(d => d.Descripcion, ocurrencia.Descripcion)
                        .SetProperty(r => r.Resumen, ocurrencia.Resumen)
                        .SetProperty(e => e.Estado, ocurrencia.Estado)
                        .SetProperty(re => re.ReportadaPor, ocurrencia.ReportadaPor)
                        .SetProperty(t => t.TipoOcurrencia, ocurrencia.TipoOcurrencia));
            await _appDBContext.SaveChangesAsync();
            return ocurrencia;
        }

        public void EliminarOcurrencia<T>(T entity) where T : class
        {
            _appDBContext.Remove(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<Ocurrencia> ObtenerOcurrenciaPorIdAsync(int id)
        {
            var ocurrencia = await _appDBContext.Ocurrencias.FirstOrDefaultAsync(x => x.Id == id);
            return ocurrencia;
        }

        public async Task<List<Ocurrencia>> ObtenerOcurrenciasAsync()
        {
            var ocurrencias = await _appDBContext.Ocurrencias.ToListAsync();
            return ocurrencias;
        }

        public Task<List<Ocurrencia>> ObtenerOcurrenciasPorEstadoDiaAsync(string estado)
        {
            throw new NotImplementedException();
        }

        //public Task<List<Ocurrencia>> ObtenerOcurrenciasPorEstadoDiaAsync(string estado)
        //{
        //    var ocurrencias = _appDBContext.Ocurrencias.Where(x => x.DiaTrabajo.Estado == estado);
        //    return ocurrencias.ToListAsync();
        //}

        public async Task<bool> SalvarCambios()
        {
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}
