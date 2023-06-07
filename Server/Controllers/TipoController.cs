using Incidencias.Server.Services;
using Incidencias.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidencias.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly TipoOcurrenciaService _tipoService;

        public TipoController(TipoOcurrenciaService tipoService)
        {
            _tipoService = tipoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tipos = await _tipoService.ObtenerTiposOcurrenciasAsync();
            if (tipos == null) { return NotFound("No he podido encontrar ningún resultado"); }
            return Ok(tipos);
        }
        [HttpPost]
        public async Task<IActionResult> Post(TipoOcurrencia tipo)
        {
            _tipoService.AgregarTipoOcurrencia(tipo);
            if (!_tipoService.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(tipo);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipo = await _tipoService.ObtenerTipoOcurrenciaPorIdAsync(id);
            if (tipo== null)
            {
                return NotFound("No he podido encontrar ningún resultado");
            }
            _tipoService.EliminarTipoOcurrencia(tipo);

            if (!_tipoService.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(tipo);
        }
    }
}
