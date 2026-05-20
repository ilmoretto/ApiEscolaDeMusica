using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("agenda"), PrimaryKey(nameof(AlunoId), nameof(TurmaId))]
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
        public virtual Aluno Aluno { get; set; }

        [ForeignKey("TurmaId")]
        public virtual Turma Turma { get; set; }
    }
}
