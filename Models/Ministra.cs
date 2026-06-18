using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    [PrimaryKey(nameof(TurmaId), nameof(ProfessorId))]
    public class Ministra
    {
        public int TurmaId { get; set; }
        public virtual Turma? Turma { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor? Professor { get; set; }
        public required DateOnly DataAtribuicao { get; set; }

    }
}
