using Incidencias.Shared.Models;

namespace Incidencias.Server.Services.Interfaces
{
    public interface IEstadoService
    {
        void AgregarEstado<T>(T entity) where T : class;
        void EliminarEstado<T>(T entity) where T : class;
        Task<bool> SalvarCambios();
        Task<List<Estado>> ObtenerEstadosAsync();
        Task<Estado> ObtenerEstadoPorIdAsync(int id);
    }
}
