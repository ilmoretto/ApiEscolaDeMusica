using AppEscolaDeMusica.Dtos.Agendas;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<Agenda, AgendaDto>().ReverseMap();
            CreateMap<Agenda, AgendaResponseDto>();
            CreateMap<AgendaUpdateDto, Agenda>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
