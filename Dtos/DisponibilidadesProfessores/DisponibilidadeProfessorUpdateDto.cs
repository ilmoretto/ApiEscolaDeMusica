using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.DisponibilidadesProfessores
{
    public class DisponibilidadeProfessorUpdateDto
    {
        public int ProfessorId { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
        public TimeOnly HorarioInicio { get; set; }
        public TimeOnly HorarioFim { get; set; }
        public StatusDisponibilidadeEnum StatusDisp { get; set; }
    }
}
