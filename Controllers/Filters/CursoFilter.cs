using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Enums;
namespace AppEscolaDeMusica.Controllers.Filters
{
    public class CursoFilter : PaginatedFilter
    {
        public string? Instrumento { get; set; } = null;
        public NivelCursoEnum? Nivel { get; set; } = null;
    }
}