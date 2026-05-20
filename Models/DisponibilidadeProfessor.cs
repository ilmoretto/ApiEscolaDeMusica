using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("disponibilidade_professor")]
    public class DisponibilidadeProfessor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_professor_id")]
        public int ProfessorId { get; set; }

        [Column("dia_semana")]
        public DiaSemanaEnum DiaSemana { get; set; }

        [Column("status_disp")]
        public StatusDisponibilidadeEnum StatusDisp { get; set; }

        [Column("horario_inicio")]
        public string Status { get; set; }

        [Column("horario_fim")]
        public string HorarioFim { get; set; }

        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }

    }
}
