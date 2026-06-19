using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;
namespace AppEscolaDeMusica.Dtos.Cursos
{
    public class CursoUpdateDto
    {
        public NivelCursoEnum? Nivel { get; set; }
        [MaxLength(100)]
        public string? Nome { get; set; }
        [MaxLength(500)]
        public string? Descricao { get; set; }
        public int? CargaHoraria { get; set; }

        public int? DuracaoMeses { get; set; }
    }
}