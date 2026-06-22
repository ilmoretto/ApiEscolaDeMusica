using Microsoft.AspNetCore.Authorization;
using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.Dtos.Agendas;
using AppEscolaDeMusica.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/agendas")]
    [Authorize]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaService _service;

        public AgendaController(AgendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AgendaFilter filter)
        {
            return Ok(await _service.GetAll(filter));
        }

        [HttpGet("{alunoId}/{turmaId}")]
        public async Task<IActionResult> GetById(int alunoId, int turmaId)
        {
            var result = await _service.GetById(alunoId, turmaId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgendaDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { alunoId = result.AlunoId, turmaId = result.TurmaId }, result);
        }

        [HttpPut("{alunoId}/{turmaId}")]
        public async Task<IActionResult> Update(int alunoId, int turmaId, [FromBody] AgendaUpdateDto dto)
        {
            var result = await _service.Update(alunoId, turmaId, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{alunoId}/{turmaId}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int alunoId, int turmaId)
        {
            var success = await _service.Delete(alunoId, turmaId);
            return success ? NoContent() : NotFound();
        }
    }
}

