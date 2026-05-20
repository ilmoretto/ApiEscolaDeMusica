using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.Agendas
{
    public class AgendaResponseDto
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public StatusAgendaEnum StatusAgenda { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}
