using System.ComponentModel.DataAnnotations;
namespace AppEscolaDeMusica.Dtos.Salas
{
    public class SalaDto
    {
        [Required, MaxLength(100)]
        public required string Nome { get; set; }
        [Required, MaxLength(100)]
        public required string Localizacao { get; set; }
        [Required, MaxLength(500)]
        public required string Equipamentos { get; set; }
        [Required]
        public required int Capacidade { get; set; }
    }
}