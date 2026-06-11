using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.Cursos
{
    public class CursoUpdateDto
    {
        public NivelCursoEnum Nivel { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required string Instrumento { get; set; }
        public required int CargaHoraria { get; set; }
        public required int DuracaoMeses { get; set; }
    }
}
