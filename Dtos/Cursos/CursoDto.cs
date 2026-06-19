using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations;
namespace AppEscolaDeMusica.Dtos.Cursos
{
    public class CursoDto
    {
        public NivelCursoEnum Nivel { get; set; } = NivelCursoEnum.Iniciante;
        [Required, MaxLength(100)]
        public required string Nome { get; set; }
        [Required, MaxLength(500)]
        public required string Descricao { get; set; }
        [Required, MaxLength(50)]
        public required string Instrumento { get; set; }
        [Required]
        public required int CargaHoraria { get; set; }
        [Required]
        public required int DuracaoMeses { get; set; }
    }
}