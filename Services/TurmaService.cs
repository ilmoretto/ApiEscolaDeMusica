using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Turmas;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Services
{
    public class TurmaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TurmaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<TurmaResponseDto>> GetAll(TurmaFilter filter)
        {
            var query = _context.Set<Turma>().AsQueryable();

            if (!string.IsNullOrEmpty(filter.Search))
                query = query.Where(r => r.Nome.Contains(filter.Search));
            if (filter.CursoId.HasValue)
                query = query.Where(r => r.CursoId == filter.CursoId.Value);
            if (filter.SalaId.HasValue)
                query = query.Where(r => r.SalaId == filter.SalaId.Value);
            if (filter.StatusTurma.HasValue)
                query = query.Where(r => r.StatusTurma == filter.StatusTurma.Value);
            if (filter.DiaSemana.HasValue)
                query = query.Where(r => r.DiaSemana == filter.DiaSemana.Value);

            return await Paginate<Turma>.Set<TurmaResponseDto>(query, filter, _mapper);
        }

        public async Task<TurmaResponseDto?> GetById(int id)
        {
            var turma = await _context.Set<Turma>().FindAsync(id);
            if (turma == null) return null;
            return _mapper.Map<TurmaResponseDto>(turma);
        }

        public async Task<TurmaResponseDto> Create(TurmaDto dto)
        {
            var turma = _mapper.Map<Turma>(dto);
            _context.Set<Turma>().Add(turma);
            await _context.SaveChangesAsync();
            return _mapper.Map<TurmaResponseDto>(turma);
        }

        public async Task<TurmaResponseDto?> Update(int id, TurmaUpdateDto dto)
        {
            var turma = await _context.Set<Turma>().FindAsync(id);
            if (turma == null) return null;
            _mapper.Map(dto, turma);
            await _context.SaveChangesAsync();
            return _mapper.Map<TurmaResponseDto>(turma);
        }

        public async Task<bool> Delete(int id)
        {
            var turma = await _context.Set<Turma>().FindAsync(id);
            if (turma == null) return false;
            _context.Set<Turma>().Remove(turma);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}