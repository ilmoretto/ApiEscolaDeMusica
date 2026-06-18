using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    [PrimaryKey(nameof(AlunoId), nameof(TurmaId))]
    public class Agenda
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public int Frequencia { get; set; }
        public StatusAgendaEnum StatusAgenda { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataCancelamento { get; set; }

        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }

        [ForeignKey("TurmaId")]
        public virtual Turma Turma { get; set; }
    }
}
