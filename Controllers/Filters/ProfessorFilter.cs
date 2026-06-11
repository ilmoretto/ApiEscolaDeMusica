
using AppEscolaDeMusica.Enums;
using AppEscolaDeMusica.Helpers.Paginated;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class ProfessorFilter : PaginatedFilter
    {
        public string? Cpf { get; set; } = null;
        public string? Especialidade { get; set; } = null;
        public StatusProfessorEnum? StatusProf { get; set; } = null;
    }
}
