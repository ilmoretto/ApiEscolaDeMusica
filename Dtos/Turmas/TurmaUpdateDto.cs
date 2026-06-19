using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.Turmas
{
    public class TurmaUpdateDto
    {
        public required string Nome { get; set; }
        public StatusTurmaEnum StatusTurma { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
        public required TimeOnly HorarioInicio { get; set; }
        public required TimeOnly HorarioFim { get; set; }
        public required int Capacidade { get; set; }
        public required int QuantidadeAulas { get; set; }
        public required DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public int CursoId { get; set; }
        public int SalaId { get; set; }
    }
}
