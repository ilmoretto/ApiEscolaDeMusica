using System.ComponentModel.DataAnnotations;
namespace AppEscolaDeMusica.Dtos.Salas
{
    public class SalaUpdateDto
    {
        [MaxLength(100)]
        public string? Nome { get; set; }
        [MaxLength(100)]
        public string? Localizacao { get; set; }
        [MaxLength(500)]
        public string? Equipamentos { get; set; }
        public int? Capacidade { get; set; }
    }
}