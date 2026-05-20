using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("ministra"), PrimaryKey(nameof(TurmaId), nameof(ProfessorId))]
    public class Ministra
    {
        [Column("fk_turma_id")]
        public int TurmaId { get; set; }
        public virtual Turma? Turma { get; set; }

        [Column("fk_professor_id")]
        public int ProfessorId { get; set; }
        public virtual Professor? Professor { get; set; }

        [Column("data_atribuicao")]
        public required DateOnly DataAtribuicao { get; set; }

    }
}
