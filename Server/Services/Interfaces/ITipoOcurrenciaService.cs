using Incidencias.Shared.Models;

namespace Incidencias.Server.Services.Interfaces
{
    public interface ITipoOcurrenciaService
    {
        void AgregarTipoOcurrencia<T>(T entity) where T : class;
        void EliminarTipoOcurrencia<T>(T entity) where T : class;
        Task<bool> SalvarCambios();
        Task<List<TipoOcurrencia>> ObtenerTiposOcurrenciasAsync();
        Task<TipoOcurrencia> ObtenerTipoOcurrenciaPorIdAsync(int id);
    }
}
