using AppEscolaDeMusica.Dtos.Turmas;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            CreateMap<TurmaDto, Turma>();
            CreateMap<TurmaUpdateDto, Turma>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Turma, TurmaResponseDto>();
        }
    }
}