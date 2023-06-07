using Incidencias.Shared.Models;

namespace Incidencias.Server.Services.Interfaces
{
    public interface IDiaTrabajoService
    {
        void AgregarDiaTrabajo<T>(T entity) where T : class;
        void EliminarDiaTrabajo<T>(T entity) where T : class;
        Task<bool> SalvarCambios();
        Task<List<DiaTrabajo>> ObtenerDiasTrabajoAsync();
        Task<DiaTrabajo> ObtenerDiaTrabajoPorIdAsync(int id);
        Task<DiaTrabajo> ObtenerDiaTrabajoPorEstadoAsync(string estado);
        Task<DiaTrabajo> EditarDiaTrabajoAsync(int id, DiaTrabajo diaTrabajo);
        Task<List<Ocurrencia>> AgregarOcurrenciaAsync(int id, Ocurrencia ocurrencia);
    }
}
