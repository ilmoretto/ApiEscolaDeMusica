using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.Cursos
{
    public class CursoResponseDto
    {
        public int Id { get; set; }
        public NivelCursoEnum Nivel { get; set; }
        public required string Nome { get; set; }
        public required string Instrumento { get; set; }
    }
}
