using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.ResponsaveisAlunos
{
    public class ResponsavelAlunoResponseDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public ParentescoEnum Parentesco { get; set; }
    }
}
