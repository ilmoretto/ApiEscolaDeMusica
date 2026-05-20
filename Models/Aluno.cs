using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
namespace AppEscolaDeMusica.Models
{
    public class Aluno
    {
        [Column("status_aluno")]
        public StatusAlunoEnum StatusAluno { get; set; }
    }
}
