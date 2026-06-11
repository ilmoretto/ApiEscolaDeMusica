using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEscolaDeMusica.Dtos.Professores

{
    public class ProfessorDto
    {
        [Required, MaxLength(100)]
        public required string Nome { get; set; }

        [Required, MaxLength(11)]
        public required string Cpf { get; set; }

        [Required, MaxLength(11)]
        public required string Rg { get; set; }

        [EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(15)]
        public required string Telefone { get; set; }

        [Required]
        public required DateOnly DataAdmissao { get; set; }

        [Required]
        public DateOnly? DataDemissao { get; set; }

        public StatusProfessorEnum StatusProf { get; set; }

        [Required, MaxLength(100)]
        public required string Especialidade { get; set; }

        [Required]
        public required decimal ValorHoraAula { get; set; }
    }
}
