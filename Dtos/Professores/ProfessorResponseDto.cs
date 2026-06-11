using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.Professores
{
    public class ProfessorResponseDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public StatusProfessorEnum StatusProf { get; set; }
        public required string Especialidade { get; set; }
    }
}
