using AppEscolaDeMusica.Helpers.Paginated;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class MinistraFilter : PaginatedFilter
    {
        public int? TurmaId { get; set; }
        public int? ProfessorId { get; set; }
    }
}
