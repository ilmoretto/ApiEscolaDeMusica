using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.DisponibilidadesProfessores
{
    public class DisponibilidadeProfessorResponseDto
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
        public TimeOnly HorarioInicio { get; set; }
        public TimeOnly HorarioFim { get; set; }
        public StatusDisponibilidadeEnum StatusDisp { get; set; }
    }
}
