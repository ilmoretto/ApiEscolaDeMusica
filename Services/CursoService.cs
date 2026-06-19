using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Cursos;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;
namespace AppEscolaDeMusica.Services
{
    public class CursoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CursoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<CursoResponseDto>> GetAll(CursoFilter filter)
        {
            var query = _context.Set<Curso>().AsQueryable();
            if (!string.IsNullOrEmpty(filter.Search))
                query = query.Where(r => r.Nome.Contains(filter.Search));
            if (!string.IsNullOrEmpty(filter.Instrumento))
                query = query.Where(r => r.Instrumento.Contains(filter.Instrumento));
            if (filter.Nivel.HasValue)
                query = query.Where(r => r.Nivel == filter.Nivel.Value);
            return await Paginate<Curso>.Set<CursoResponseDto>(query, filter, _mapper);
        }
        public async Task<CursoResponseDto?> GetById(int id)
        {
            var curso = await _context.Set<Curso>().FindAsync(id);
            if (curso == null) return null;
            return _mapper.Map<CursoResponseDto>(curso);
        }
        public async Task<CursoResponseDto> Create(CursoDto dto)
        {
            var curso = _mapper.Map<Curso>(dto);
            _context.Set<Curso>().Add(curso);
            await _context.SaveChangesAsync();
            return _mapper.Map<CursoResponseDto>(curso);
        }
        public async Task<CursoResponseDto?> Update(int id, CursoUpdateDto dto)
        {
            var curso = await _context.Set<Curso>().FindAsync(id);
            if (curso == null) return null;
            _mapper.Map(dto, curso);
            await _context.SaveChangesAsync();
            return _mapper.Map<CursoResponseDto>(curso);
        }
        public async Task<bool> Delete(int id)
        {
            var curso = await _context.Set<Curso>().FindAsync(id);
            if (curso == null) return false;
            _context.Set<Curso>().Remove(curso);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}