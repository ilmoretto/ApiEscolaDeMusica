using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Ministras;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Services
{
    public class MinistraService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MinistraService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<MinistraResponseDto>> GetAll(MinistraFilter filter)
        {
            var query = _context.Set<Ministra>().AsQueryable();

            if (filter.TurmaId.HasValue)
                query = query.Where(r => r.TurmaId == filter.TurmaId.Value);
            if (filter.ProfessorId.HasValue)
                query = query.Where(r => r.ProfessorId == filter.ProfessorId.Value);

            return await Paginate<Ministra>.Set<MinistraResponseDto>(query, filter, _mapper);
        }

        public async Task<MinistraResponseDto?> GetById(int turmaId, int professorId)
        {
            var ministra = await _context.Set<Ministra>().FindAsync(turmaId, professorId);
            if (ministra == null) return null;
            return _mapper.Map<MinistraResponseDto>(ministra);
        }

        public async Task<MinistraResponseDto> Create(MinistraDto dto)
        {
            var ministra = _mapper.Map<Ministra>(dto);
            _context.Set<Ministra>().Add(ministra);
            await _context.SaveChangesAsync();
            return _mapper.Map<MinistraResponseDto>(ministra);
        }

        public async Task<MinistraResponseDto?> Update(int turmaId, int professorId, MinistraUpdateDto dto)
        {
            var ministra = await _context.Set<Ministra>().FindAsync(turmaId, professorId);
            if (ministra == null) return null;

            _mapper.Map(dto, ministra);
            await _context.SaveChangesAsync();
            return _mapper.Map<MinistraResponseDto>(ministra);
        }

        public async Task<bool> Delete(int turmaId, int professorId)
        {
            var ministra = await _context.Set<Ministra>().FindAsync(turmaId, professorId);
            if (ministra == null) return false;
            
            _context.Set<Ministra>().Remove(ministra);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
