using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.Alunos;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Services
{
    public class AlunoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlunoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<AlunoResponseDto>> GetAll(AlunoFilter filter)
        {
            var query = _context.Set<Aluno>().AsQueryable();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                query = query.Where(r => r.Nome.Contains(filter.Search));
            }

            if (!string.IsNullOrEmpty(filter.Cpf))
            {
                query = query.Where(r => r.Cpf == filter.Cpf);
            }

            if (filter.ResponsavelId.HasValue)
            {
                query = query.Where(r => r.ResponsavelId == filter.ResponsavelId.Value);
            }

            return await Paginate<Aluno>.Set<AlunoResponseDto>(query, filter, _mapper);
        }

        public async Task<AlunoResponseDto?> GetById(int id)
        {
            var aluno = await _context.Set<Aluno>().FindAsync(id);
            if (aluno == null) return null;

            return _mapper.Map<AlunoResponseDto>(aluno);
        }

        public async Task<AlunoResponseDto> Create(AlunoDto dto)
        {
            var aluno = _mapper.Map<Aluno>(dto);
            
            _context.Set<Aluno>().Add(aluno);
            await _context.SaveChangesAsync();

            return _mapper.Map<AlunoResponseDto>(aluno);
        }

        public async Task<AlunoResponseDto?> Update(int id, AlunoUpdateDto dto)
        {
            var aluno = await _context.Set<Aluno>().FindAsync(id);
            if (aluno == null) return null;

            _mapper.Map(dto, aluno);
            await _context.SaveChangesAsync();

            return _mapper.Map<AlunoResponseDto>(aluno);
        }

        public async Task<bool> Delete(int id)
        {
            var aluno = await _context.Set<Aluno>().FindAsync(id);
            if (aluno == null) return false;

            _context.Set<Aluno>().Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
