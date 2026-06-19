using AppEscolaDeMusica.Helpers.Paginated;
using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Controllers.Filters
{
    public class DisponibilidadeProfessorFilter : PaginatedFilter
    {
        public int? ProfessorId { get; set; } = null;
        public DiaSemanaEnum? DiaSemana { get; set; } = null;
        public StatusDisponibilidadeEnum? StatusDisp { get; set; } = null;
    }
}