using AppEscolaDeMusica.Dtos.Ministras;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class MinistraProfile : Profile
    {
        public MinistraProfile()
        {
            CreateMap<Ministra, MinistraDto>().ReverseMap();
            CreateMap<Ministra, MinistraResponseDto>();
            CreateMap<MinistraUpdateDto, Ministra>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
