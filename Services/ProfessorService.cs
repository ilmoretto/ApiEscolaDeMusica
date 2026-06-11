using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Professores;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Services
{
    public class ProfessorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProfessorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<ProfessorResponseDto>> GetAll(ProfessorFilter filter)
        {
            var query = _context.Set<Professor>().AsQueryable();
            if (!string.IsNullOrEmpty(filter.Search))
                query = query.Where(r => r.Nome.Contains(filter.Search));
            if (!string.IsNullOrEmpty(filter.Cpf))
                query = query.Where(r => r.Cpf == filter.Cpf);
            if (!string.IsNullOrEmpty(filter.Especialidade))
                query = query.Where(r => r.Especialidade.Contains(filter.Especialidade));
            if (filter.StatusProf.HasValue)
                query = query.Where(r => r.StatusProf == filter.StatusProf.Value);
            return await Paginate<Professor>.Set<ProfessorResponseDto>(query, filter, _mapper);
        }
        public async Task<ProfessorResponseDto?> GetById(int id)
        {
            var professor = await _context.Set<Professor>().FindAsync(id);
            if (professor == null) return null;
            return _mapper.Map<ProfessorResponseDto>(professor);
        }
        public async Task<ProfessorResponseDto> Create(ProfessorDto dto)
        {
            var professor = _mapper.Map<Professor>(dto);
            _context.Set<Professor>().Add(professor);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProfessorResponseDto>(professor);
        }
        public async Task<ProfessorResponseDto?> Update(int id, ProfessorUpdateDto dto)
        {
            var professor = await _context.Set<Professor>().FindAsync(id);
            if (professor == null) return null;
            _mapper.Map(dto, professor);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProfessorResponseDto>(professor);
        }
        public async Task<bool> Delete(int id)
        {
            var professor = await _context.Set<Professor>().FindAsync(id);
            if (professor == null) return false;
            _context.Set<Professor>().Remove(professor);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
