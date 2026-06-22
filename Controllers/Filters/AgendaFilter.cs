using AppEscolaDeMusica.Enums;
using AppEscolaDeMusica.Helpers.Paginated;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class AgendaFilter : PaginatedFilter
    {
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        public StatusAgendaEnum? StatusAgenda { get; set; }
    }
}
