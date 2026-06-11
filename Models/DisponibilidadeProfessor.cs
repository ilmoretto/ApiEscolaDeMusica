using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("disponibilidade_professor"), PrimaryKey(nameof(Id))]
    public class DisponibilidadeProfessor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_professor_id")]
        public int ProfessorId { get; set; }

        [Column("dia_semana")]
        public DiaSemanaEnum DiaSemana { get; set; }

        [Column("horario_inicio")]
        public TimeOnly HorarioInicio { get; set; }

        [Column("horario_fim")]
        public TimeOnly HorarioFim { get; set; }

        [Column("status_disp")]
        public StatusDisponibilidadeEnum StatusDisp { get; set; }

        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }
    }
}
