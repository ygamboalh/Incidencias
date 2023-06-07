using Incidencias.Server.Services;
using Incidencias.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidencias.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _estadoServices;

        public EstadoController(EstadoService estadoService)
        {
            _estadoServices = estadoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var estados = await _estadoServices.ObtenerEstadosAsync();    
            if (estados == null) { return NotFound("No he podido encontrar ningún resultado"); }
            return Ok(estados);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Estado estado)
        {
            _estadoServices.AgregarEstado(estado);
            if (!_estadoServices.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(estado);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estado = await _estadoServices.ObtenerEstadoPorIdAsync(id);
            if (estado == null) 
            {
                return NotFound("No he podido encontrar ningún resultado");
            }
            _estadoServices.EliminarEstado(estado);
            if (!_estadoServices.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(estado);
        }
    }
}
