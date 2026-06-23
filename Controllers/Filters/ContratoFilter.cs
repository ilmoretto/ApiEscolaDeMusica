using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class ContratoFilter : PaginatedFilter
    {
        public int? AlunoId { get; set; } = null;
        public int? CursoId { get; set; } = null;
        public StatusContratoEnum? StatusContrato { get; set; } = null;
    }
}