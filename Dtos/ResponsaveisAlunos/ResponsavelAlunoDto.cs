using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEscolaDeMusica.Dtos.ResponsaveisAlunos
{
    public class ResponsavelAlunoDto
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

        [Required]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public ParentescoEnum Parentesco { get; set; }
    }
}
