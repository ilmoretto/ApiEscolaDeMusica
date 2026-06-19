using AppEscolaDeMusica.Dtos.DisponibilidadesProfessores;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class DisponibilidadeProfessorProfile : Profile
    {
        public DisponibilidadeProfessorProfile()
        {
            CreateMap<DisponibilidadeProfessorDto, DisponibilidadeProfessor>();
            CreateMap<DisponibilidadeProfessorUpdateDto, DisponibilidadeProfessor>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<DisponibilidadeProfessor, DisponibilidadeProfessorResponseDto>();
        }
    }
}