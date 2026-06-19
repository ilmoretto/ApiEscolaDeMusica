using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class TurmaFilter : PaginatedFilter
    {
        public int? CursoId { get; set; } = null;
        public int? SalaId { get; set; } = null;
        public StatusTurmaEnum? StatusTurma { get; set; } = null;
        public DiaSemanaEnum? DiaSemana { get; set; } = null;
    }
}