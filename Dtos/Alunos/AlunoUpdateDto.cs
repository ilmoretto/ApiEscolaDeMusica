using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.DTOs.Alunos
{
    public class AlunoUpdateDto
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int ResponsavelId { get; set; }
        public DateTime DataMatricula { get; set; }
        public StatusAlunoEnum StatusAluno { get; set; }
    }
}
