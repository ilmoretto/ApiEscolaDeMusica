using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Salas;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;
namespace AppEscolaDeMusica.Services
{
    public class SalaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SalaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<SalaResponseDto>> GetAll(SalaFilter filter)
        {
            var query = _context.Set<Sala>().AsQueryable();
            if (!string.IsNullOrEmpty(filter.Search))
                query = query.Where(r => r.Nome.Contains(filter.Search));
            return await Paginate<Sala>.Set<SalaResponseDto>(query, filter, _mapper);
        }
        public async Task<SalaResponseDto?> GetById(int id)
        {
            var sala = await _context.Set<Sala>().FindAsync(id);
            if (sala == null) return null;
            return _mapper.Map<SalaResponseDto>(sala);
        }
        public async Task<SalaResponseDto> Create(SalaDto dto)
        {
            var sala = _mapper.Map<Sala>(dto);
            _context.Set<Sala>().Add(sala);
            await _context.SaveChangesAsync();
            return _mapper.Map<SalaResponseDto>(sala);
        }
        public async Task<SalaResponseDto?> Update(int id, SalaUpdateDto dto)
        {
            var sala = await _context.Set<Sala>().FindAsync(id);
            if (sala == null) return null;
            _mapper.Map(dto, sala);
            await _context.SaveChangesAsync();
            return _mapper.Map<SalaResponseDto>(sala);
        }
        public async Task<bool> Delete(int id)
        {
            var sala = await _context.Set<Sala>().FindAsync(id);
            if (sala == null) return false;
            _context.Set<Sala>().Remove(sala);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}