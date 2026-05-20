using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.ResponsaveisAlunos
{
    public class ResponsavelAlunoCreateDto
    {
        public required string Cpf { get; set; }
        public required string Rg { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public ParentescoEnum Parentesco { get; set; }
    }
}
