using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppEscolaDeMusica.Dtos.Professores
{
    public class ProfessorUpdateDto
    {
        [MaxLength(100)]
        public required string Nome { get; set; }

        [EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        
        [MaxLength(15)]
        public required string Telefone { get; set; }

        public DateOnly? DataDemissao { get; set; }

        public StatusProfessorEnum StatusProf { get; set; }


        public required decimal ValorHoraAula { get; set; }
    }
}
