using AppEscolaDeMusica.Dtos.Alunos;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<AlunoDto, Aluno>();
            CreateMap<AlunoUpdateDto, Aluno>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Aluno, AlunoResponseDto>();
        }
    }
}
