using AppEscolaDeMusica.Controllers.Filters;
using AppEscolaDeMusica.DataContexts;
using AppEscolaDeMusica.Dtos.ResponsaveisAlunos;
using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Services
{
    public class ResponsavelAlunoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ResponsavelAlunoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<ResponsavelAlunoResponseDto>> GetAll(ResponsavelAlunoFilter filter)
        {
            var query = _context.Set<ResponsavelAluno>().AsQueryable();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                query = query.Where(r => r.Nome.Contains(filter.Search));
            }

            if (!string.IsNullOrEmpty(filter.Cpf))
            {
                query = query.Where(r => r.Cpf == filter.Cpf);
            }

            return await Paginate<ResponsavelAluno>.Set<ResponsavelAlunoResponseDto>(query, filter, _mapper);
        }

        public async Task<ResponsavelAlunoResponseDto?> GetById(int id)
        {
            var responsavel = await _context.Set<ResponsavelAluno>().FindAsync(id);
            if (responsavel == null) return null;

            return _mapper.Map<ResponsavelAlunoResponseDto>(responsavel);
        }

        public async Task<ResponsavelAlunoResponseDto> Create(ResponsavelAlunoDto dto)
        {
            var responsavel = _mapper.Map<ResponsavelAluno>(dto);
            
            _context.Set<ResponsavelAluno>().Add(responsavel);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponsavelAlunoResponseDto>(responsavel);
        }

        public async Task<ResponsavelAlunoResponseDto?> Update(int id, ResponsavelAlunoUpdateDto dto)
        {
            var responsavel = await _context.Set<ResponsavelAluno>().FindAsync(id);
            if (responsavel == null) return null;

            _mapper.Map(dto, responsavel);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponsavelAlunoResponseDto>(responsavel);
        }

        public async Task<bool> Delete(int id)
        {
            var responsavel = await _context.Set<ResponsavelAluno>().FindAsync(id);
            if (responsavel == null) return false;

            _context.Set<ResponsavelAluno>().Remove(responsavel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
