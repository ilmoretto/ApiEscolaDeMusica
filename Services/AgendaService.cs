using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Agendas;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AppEscolaDeMusica.Enums;
using AutoMapper;

namespace AppEscolaDeMusica.Services
{
    public class AgendaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AgendaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<AgendaResponseDto>> GetAll(AgendaFilter filter)
        {
            var query = _context.Set<Agenda>().AsQueryable();

            if (filter.AlunoId.HasValue)
                query = query.Where(r => r.AlunoId == filter.AlunoId.Value);
            if (filter.TurmaId.HasValue)
                query = query.Where(r => r.TurmaId == filter.TurmaId.Value);
            if (filter.StatusAgenda.HasValue)
                query = query.Where(r => r.StatusAgenda == filter.StatusAgenda.Value);

            return await Paginate<Agenda>.Set<AgendaResponseDto>(query, filter, _mapper);
        }

        public async Task<AgendaResponseDto?> GetById(int alunoId, int turmaId)
        {
            var agenda = await _context.Set<Agenda>().FindAsync(alunoId, turmaId);
            if (agenda == null) return null;
            return _mapper.Map<AgendaResponseDto>(agenda);
        }

        public async Task<AgendaResponseDto> Create(AgendaDto dto)
        {
            var agenda = _mapper.Map<Agenda>(dto);
            _context.Set<Agenda>().Add(agenda);
            await _context.SaveChangesAsync();
            return _mapper.Map<AgendaResponseDto>(agenda);
        }

        public async Task<AgendaResponseDto?> Update(int alunoId, int turmaId, AgendaUpdateDto dto)
        {
            var agenda = await _context.Set<Agenda>().FindAsync(alunoId, turmaId);
            if (agenda == null) return null;

            _mapper.Map(dto, agenda);
            
            // Lógica de cancelamento (atribuir data atual)
            if (agenda.StatusAgenda == StatusAgendaEnum.Cancelado && agenda.DataCancelamento == null)
            {
                agenda.DataCancelamento = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<AgendaResponseDto>(agenda);
        }

        public async Task<bool> Delete(int alunoId, int turmaId)
        {
            var agenda = await _context.Set<Agenda>().FindAsync(alunoId, turmaId);
            if (agenda == null) return false;
            
            _context.Set<Agenda>().Remove(agenda);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
