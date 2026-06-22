using Microsoft.AspNetCore.Authorization;
using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.Dtos.Contratos;
using AppEscolaDeMusica.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contratos")]
    [Authorize]
    public class ContratoController : ControllerBase
    {
        private readonly ContratoService _service;

        public ContratoController(ContratoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ContratoFilter filter)
        {
            return Ok(await _service.GetAll(filter));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContratoDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContratoUpdateDto dto)
        {
            var result = await _service.Update(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}

