using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.Professores
{
    public class ProfessorUpdateDto
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string Rg { get; set; }
        public string Email { get; set; }
        public required string Telefone { get; set; }
        public required DateOnly DataAdmissao { get; set; }
        public DateOnly? DataDemissao { get; set; }
        public StatusProfessorEnum StatusProf { get; set; }
        public required string Especialidade { get; set; }
        public required decimal ValorHoraAula { get; set; }
    }
}
