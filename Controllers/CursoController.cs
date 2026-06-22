using Microsoft.AspNetCore.Authorization;
using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.Dtos.Cursos;
using AppEscolaDeMusica.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cursos")]
    [Authorize]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _service;
        public CursoController(CursoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CursoFilter filter)
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
        public async Task<IActionResult> Create([FromBody] CursoDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CursoUpdateDto dto)
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
