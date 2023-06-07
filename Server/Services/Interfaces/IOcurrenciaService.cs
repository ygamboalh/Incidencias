using Incidencias.Shared.Models;

namespace Incidencias.Server.Services.Interfaces
{
    public interface IOcurrenciaService
    {
        void AgregarOcurrencia<T>(T entity) where T : class;
        void EliminarOcurrencia<T>(T entity) where T : class;
        Task<bool> SalvarCambios();
        Task<List<Ocurrencia>> ObtenerOcurrenciasAsync();
        Task<Ocurrencia> ObtenerOcurrenciaPorIdAsync(int id);
        Task<List<Ocurrencia>> ObtenerOcurrenciasPorEstadoDiaAsync(string estado);
        Task<Ocurrencia> EditarOcurrenciaAsync(Ocurrencia ocurrencia);
    }
}
