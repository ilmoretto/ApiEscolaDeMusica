using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEscolaDeMusica.Dtos.Alunos
{
    public class AlunoDto
    {
        [Required]
        [MaxLength(11)]
        public required string Cpf { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Rg { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Nome { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public int ResponsavelId { get; set; }

        public DateTime DataMatricula { get; set; } = DateTime.Now;

        public StatusAlunoEnum StatusAluno { get; set; } = StatusAlunoEnum.Ativo;
    }
}
