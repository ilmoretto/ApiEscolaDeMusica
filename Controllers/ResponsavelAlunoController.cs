using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.Dtos.ResponsaveisAlunos;
using AppEscolaDeMusica.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AppEscolaDeMusica.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/responsaveis-alunos")]
    public class ResponsavelAlunoController : ControllerBase
    {
        private readonly ResponsavelAlunoService _service;

        public ResponsavelAlunoController(ResponsavelAlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ResponsavelAlunoFilter filter)
        {
            var result = await _service.GetAll(filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResponsavelAlunoDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResponsavelAlunoUpdateDto dto)
        {
            var result = await _service.Update(id, dto);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
