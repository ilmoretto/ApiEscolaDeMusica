using Microsoft.AspNetCore.Authorization;
using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.Dtos.Ministras;
using AppEscolaDeMusica.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/ministras")]
    [Authorize]
    public class MinistraController : ControllerBase
    {
        private readonly MinistraService _service;

        public MinistraController(MinistraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MinistraFilter filter)
        {
            return Ok(await _service.GetAll(filter));
        }

        [HttpGet("{turmaId}/{professorId}")]
        public async Task<IActionResult> GetById(int turmaId, int professorId)
        {
            var result = await _service.GetById(turmaId, professorId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MinistraDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { turmaId = result.TurmaId, professorId = result.ProfessorId }, result);
        }

        [HttpPut("{turmaId}/{professorId}")]
        public async Task<IActionResult> Update(int turmaId, int professorId, [FromBody] MinistraUpdateDto dto)
        {
            var result = await _service.Update(turmaId, professorId, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{turmaId}/{professorId}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int turmaId, int professorId)
        {
            var success = await _service.Delete(turmaId, professorId);
            return success ? NoContent() : NotFound();
        }
    }
}

