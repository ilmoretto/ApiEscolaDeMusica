using AppEscolaDeMusica.Dtos.Professores;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<ProfessorDto, Professor>();
            CreateMap<ProfessorUpdateDto, Professor>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Professor, ProfessorResponseDto>();
        }
    }
}
