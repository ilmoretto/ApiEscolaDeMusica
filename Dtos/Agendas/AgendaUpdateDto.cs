using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.Agendas
{
    public class AgendaUpdateDto
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public int Frequencia { get; set; }
        public StatusAgendaEnum StatusAgenda { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
