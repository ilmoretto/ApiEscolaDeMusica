using AppEscolaDeMusica.Dtos.Salas;
using AppEscolaDeMusica.Models;
using AutoMapper;
namespace AppEscolaDeMusica.Profiles
{
    public class SalaProfile : Profile
    {
        public SalaProfile()
        {
            CreateMap<SalaDto, Sala>();
            CreateMap<SalaUpdateDto, Sala>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Sala, SalaResponseDto>();
        }
    }
}