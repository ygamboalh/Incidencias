using Incidencias.Server.Services;
using Incidencias.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidencias.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiaTrabajoController : ControllerBase
    {
        private readonly DiaTrabajoService _diaTrabajoService;

        public DiaTrabajoController(DiaTrabajoService diaTrabajoService)
        {
            _diaTrabajoService = diaTrabajoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dias = await _diaTrabajoService.ObtenerDiasTrabajoAsync();    
            if (dias == null) { return NotFound("No he podido encontrar ningún resultado"); }
            return Ok(dias);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dia = await _diaTrabajoService.ObtenerDiaTrabajoPorIdAsync(id);
            if (dia == null)
            {
                return NotFound("No he podido encontrar ningún resultado");
            }
            return Ok(dia);
        }
        [HttpPost]
        public async Task<IActionResult> Post(DiaTrabajo dia)
        {
            string estado = "Abierto";
            var diaTrabajoDB = _diaTrabajoService.ObtenerDiaTrabajoPorEstadoAsync(estado);
            if (diaTrabajoDB.Result != null) 
            {
                return BadRequest("Solo puede tener un Dia trabajo Abierto");
            }
            _diaTrabajoService.AgregarDiaTrabajo(dia);
            if (!_diaTrabajoService.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(dia);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dia = await _diaTrabajoService.ObtenerDiaTrabajoPorIdAsync(id);
            if (dia == null) 
            {
                return NotFound("No he podido encontrar ningún resultado-Dia");
            }
            _diaTrabajoService.EliminarDiaTrabajo(dia);
            if (!_diaTrabajoService.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(dia);
        }
    }
}
