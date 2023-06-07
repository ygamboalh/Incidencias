using Incidencias.Server.Services.Interfaces;
using Incidencias.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Incidencias.Server.Services
{
    public class DiaTrabajoService : IDiaTrabajoService
    {
        private readonly AppDBContext _appDBContext;

        public DiaTrabajoService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void AgregarDiaTrabajo<T>(T entity) where T : class
        {
            _appDBContext.Add(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<List<Ocurrencia>> AgregarOcurrenciaAsync(int id, Ocurrencia ocurrencia)
        {
            var dia = await _appDBContext.DiaTrabajos.FirstOrDefaultAsync(x => x.Id == id);
            dia.Ocurrencias.Add(ocurrencia);
            return dia.Ocurrencias;
        }

        public async Task<DiaTrabajo> EditarDiaTrabajoAsync(int id, DiaTrabajo diaTrabajo)
        {
            var diatrabajoDb = await _appDBContext.DiaTrabajos.FirstOrDefaultAsync(d => d.Id == id);
            //Tengo que hacer un mapper para pasar los datos de diatrabajo para diatrabajodb
            return diatrabajoDb;
        }

        public void EliminarDiaTrabajo<T>(T entity) where T : class
        {
            _appDBContext.Remove(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<List<DiaTrabajo>> ObtenerDiasTrabajoAsync()
        {
            var dias = await _appDBContext.DiaTrabajos.ToListAsync();
            return dias;
        }

        public async Task<DiaTrabajo> ObtenerDiaTrabajoPorIdAsync(int id)
        {
            var dia = await _appDBContext.DiaTrabajos.FirstOrDefaultAsync(x => x.Id == id);
            return dia;
        }
        public async Task<DiaTrabajo> ObtenerDiaTrabajoPorEstadoAsync(string estado)
        {
            var dia = await _appDBContext.DiaTrabajos.FirstOrDefaultAsync(x => x.Estado == estado);
            return dia;
        }

        public async Task<bool> SalvarCambios()
        {
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}
