using AppEscolaDeMusica.Dtos.ResponsaveisAlunos;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class ResponsavelAlunoProfile : Profile
    {
        public ResponsavelAlunoProfile()
        {
            CreateMap<ResponsavelAlunoDto, ResponsavelAluno>();
            CreateMap<ResponsavelAlunoUpdateDto, ResponsavelAluno>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ResponsavelAluno, ResponsavelAlunoResponseDto>();
        }
    }
}
