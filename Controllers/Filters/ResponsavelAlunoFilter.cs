using AppEscolaDeMusica.Helpers.Paginated;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class ResponsavelAlunoFilter : PaginatedFilter
    {
        public string? Cpf { get; set; } = null;
    }
}
