namespace AppEscolaDeMusica.DTOs.Salas
{
    public class SalaUpdateDto
    {
        public required string Nome { get; set; }
        public required string Localizacao { get; set; }
        public required string Equipamentos { get; set; }
        public required int Capacidade { get; set; }
    }
}
