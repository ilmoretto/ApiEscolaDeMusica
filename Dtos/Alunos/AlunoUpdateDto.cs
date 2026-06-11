using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEscolaDeMusica.Dtos.Alunos
{
    public class AlunoUpdateDto
    {
        [MaxLength(150)]
        public string? Nome { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Telefone { get; set; }

        public StatusAlunoEnum? StatusAluno { get; set; }
    }
}
