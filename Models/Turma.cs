using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("turma"), PrimaryKey(nameof(Id))]
    public class Turma
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public required string Nome { get; set; }

        [Column("status_turma")]
        public StatusTurmaEnum StatusTurma { get; set; }

        [Column("dia_semana")]
        public DiaSemanaEnum DiaSemana { get; set; }

        [Column("horario_inicio")]
        public required TimeOnly HorarioInicio { get; set; }

        [Column("horario_fim")]
        public required TimeOnly HorarioFim { get; set; }

        [Column("capacidade")]
        public required int Capacidade { get; set; }

        [Column("quantidade_aulas")]
        public required int QuantidadeAulas { get; set; }

        [Column("data_inicio")]
        public required DateOnly DataInicio { get; set; }

        [Column("data_fim")]
        public required DateOnly DataFim { get; set; }

        [Column("fk_curso")]
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        [Column("fk_sala")]
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; }

        public ICollection<Ministra>? Ministra { get; set; }
    }
}
