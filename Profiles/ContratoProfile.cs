using AppEscolaDeMusica.Dtos.Contratos;
using AppEscolaDeMusica.Models;
using AutoMapper;

namespace AppEscolaDeMusica.Profiles
{
    public class ContratoProfile : Profile
    {
        public ContratoProfile()
        {
            CreateMap<Contrato, ContratoDto>().ReverseMap();
            CreateMap<Contrato, ContratoResponseDto>();
            CreateMap<ContratoUpdateDto, Contrato>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
