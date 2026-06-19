using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.DisponibilidadesProfessores;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Services
{
    public class DisponibilidadeProfessorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DisponibilidadeProfessorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<DisponibilidadeProfessorResponseDto>> GetAll(DisponibilidadeProfessorFilter filter)
        {
            var query = _context.Set<DisponibilidadeProfessor>().AsQueryable();

            if (filter.ProfessorId.HasValue)
                query = query.Where(r => r.ProfessorId == filter.ProfessorId.Value);
            if (filter.DiaSemana.HasValue)
                query = query.Where(r => r.DiaSemana == filter.DiaSemana.Value);
            if (filter.StatusDisp.HasValue)
                query = query.Where(r => r.StatusDisp == filter.StatusDisp.Value);

            return await Paginate<DisponibilidadeProfessor>.Set<DisponibilidadeProfessorResponseDto>(query, filter, _mapper);
        }

        public async Task<DisponibilidadeProfessorResponseDto?> GetById(int id)
        {
            var disponibilidade = await _context.Set<DisponibilidadeProfessor>().FindAsync(id);
            if (disponibilidade == null) return null;
            return _mapper.Map<DisponibilidadeProfessorResponseDto>(disponibilidade);
        }

        public async Task<DisponibilidadeProfessorResponseDto> Create(DisponibilidadeProfessorDto dto)
        {
            var disponibilidade = _mapper.Map<DisponibilidadeProfessor>(dto);
            _context.Set<DisponibilidadeProfessor>().Add(disponibilidade);
            await _context.SaveChangesAsync();
            return _mapper.Map<DisponibilidadeProfessorResponseDto>(disponibilidade);
        }

        public async Task<DisponibilidadeProfessorResponseDto?> Update(int id, DisponibilidadeProfessorUpdateDto dto)
        {
            var disponibilidade = await _context.Set<DisponibilidadeProfessor>().FindAsync(id);
            if (disponibilidade == null) return null;
            _mapper.Map(dto, disponibilidade);
            await _context.SaveChangesAsync();
            return _mapper.Map<DisponibilidadeProfessorResponseDto>(disponibilidade);
        }

        public async Task<bool> Delete(int id)
        {
            var disponibilidade = await _context.Set<DisponibilidadeProfessor>().FindAsync(id);
            if (disponibilidade == null) return false;
            _context.Set<DisponibilidadeProfessor>().Remove(disponibilidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
