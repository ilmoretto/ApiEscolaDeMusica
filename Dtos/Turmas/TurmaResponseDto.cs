using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.Turmas
{
    public class TurmaResponseDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public StatusTurmaEnum StatusTurma { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
        public required TimeOnly HorarioInicio { get; set; }
        public required TimeOnly HorarioFim { get; set; }
        public int CursoId { get; set; }
        public int SalaId { get; set; }
    }
}
