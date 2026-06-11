using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.Alunos
{
    public class AlunoResponseDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public StatusAlunoEnum StatusAluno { get; set; }
        public int ResponsavelId { get; set; }
    }
}
