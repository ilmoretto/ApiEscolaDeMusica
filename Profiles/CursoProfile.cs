using AppEscolaDeMusica.Dtos.Cursos;
using AppEscolaDeMusica.Models;
using AutoMapper;
namespace AppEscolaDeMusica.Profiles
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<CursoDto, Curso>();
            CreateMap<CursoUpdateDto, Curso>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Curso, CursoResponseDto>();
        }
    }
}