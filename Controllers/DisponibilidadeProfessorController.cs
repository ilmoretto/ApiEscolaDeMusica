using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.Dtos.DisponibilidadesProfessores;
using AppEscolaDeMusica.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/disponibilidades-professores")]
    public class DisponibilidadeProfessorController : ControllerBase
    {
        private readonly DisponibilidadeProfessorService _service;

        public DisponibilidadeProfessorController(DisponibilidadeProfessorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DisponibilidadeProfessorFilter filter)
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
        public async Task<IActionResult> Create([FromBody] DisponibilidadeProfessorDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DisponibilidadeProfessorUpdateDto dto)
        {
            var result = await _service.Update(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}