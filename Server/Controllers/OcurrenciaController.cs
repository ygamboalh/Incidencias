using Incidencias.Server.Services;
using Incidencias.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidencias.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OcurrenciaController : ControllerBase
    {
        private readonly OcurrenciaService _ocurrenciaService;

        public OcurrenciaController(OcurrenciaService ocurrenciaService)
        {
            _ocurrenciaService = ocurrenciaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ocurrencias = await _ocurrenciaService.ObtenerOcurrenciasAsync();    
            if (ocurrencias == null) { return NotFound("No he podido encontrar ningún resultado"); }
            return Ok(ocurrencias);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var ocurrencia = await _ocurrenciaService.ObtenerOcurrenciaPorIdAsync(id);
            if (ocurrencia == null)
            {
                return NotFound("No he podido encontrar ningún resultado");
            }
            return Ok(ocurrencia);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Ocurrencia ocurrencia)
        {
            _ocurrenciaService.AgregarOcurrencia(ocurrencia);
            if (!_ocurrenciaService.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(ocurrencia);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ocurrencia = await _ocurrenciaService.ObtenerOcurrenciaPorIdAsync(id);
            if (ocurrencia == null) 
            {
                return NotFound("No he podido encontrar ningún resultado");
            }
            _ocurrenciaService.EliminarOcurrencia(ocurrencia);
            if (!_ocurrenciaService.SalvarCambios().Result)
            {
                return BadRequest("No he podido concluir la operación. Intente de nuevo");
            }
            return Ok(ocurrencia);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Ocurrencia ocurrencia) 
        {
            _ocurrenciaService.EditarOcurrenciaAsync(ocurrencia);
            
            return Ok(ocurrencia);
        }
    }
}
