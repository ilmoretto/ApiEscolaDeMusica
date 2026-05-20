using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("agenda")]
    public class Agenda
    {
        [Column("fk_aluno_id")]
        public int AlunoId { get; set; }

        [Column("fk_turma_id")]
        public int TurmaId { get; set; }

        [Column("frequencia")]
        public int Frequencia { get; set; }

        [Column("status_agenda")]
        public StatusAgendaEnum StatusAgenda { get; set; }

        [Column("data_inscricao")]
        public DateTime DataInscricao { get; set; }

        [Column("data_cancelamento")]
        public DateTime? DataCancelamento { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        [ForeignKey("TurmaId")]
        public Turma Turma { get; set; }


    }
}
