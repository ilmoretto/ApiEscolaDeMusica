using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Contratos;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Services
{
    public class ContratoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContratoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<ContratoResponseDto>> GetAll(ContratoFilter filter)
        {
            var query = _context.Set<Contrato>().AsQueryable();

            if (filter.AlunoId.HasValue)
                query = query.Where(r => r.AlunoId == filter.AlunoId.Value);
            if (filter.CursoId.HasValue)
                query = query.Where(r => r.CursoId == filter.CursoId.Value);
            if (filter.StatusContrato.HasValue)
                query = query.Where(r => r.StatusContrato == filter.StatusContrato.Value);

            return await Paginate<Contrato>.Set<ContratoResponseDto>(query, filter, _mapper);
        }

        public async Task<ContratoResponseDto?> GetById(int id)
        {
            var contrato = await _context.Set<Contrato>().FindAsync(id);
            if (contrato == null) return null;
            return _mapper.Map<ContratoResponseDto>(contrato);
        }

        public async Task<ContratoResponseDto> Create(ContratoDto dto)
        {
            var contrato = _mapper.Map<Contrato>(dto);
            _context.Set<Contrato>().Add(contrato);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContratoResponseDto>(contrato);
        }

        public async Task<ContratoResponseDto?> Update(int id, ContratoUpdateDto dto)
        {
            var contrato = await _context.Set<Contrato>().FindAsync(id);
            if (contrato == null) return null;
            
            _mapper.Map(dto, contrato);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContratoResponseDto>(contrato);
        }

        public async Task<bool> Delete(int id)
        {
            var contrato = await _context.Set<Contrato>().FindAsync(id);
            if (contrato == null) return false;
            
            _context.Set<Contrato>().Remove(contrato);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
