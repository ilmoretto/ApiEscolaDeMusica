using AppEscolaDeMusica.Helpers.Paginated;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class AlunoFilter : PaginatedFilter
    {
        public string? Cpf { get; set; } = null;
        public int? ResponsavelId { get; set; } = null;
    }
}
