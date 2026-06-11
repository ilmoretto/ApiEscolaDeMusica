namespace AppEscolaDeMusica.Dtos.Salas
{
    public class SalaCreateDto
    {
        public required string Nome { get; set; }
        public required string Localizacao { get; set; }
        public required string Equipamentos { get; set; }
        public required int Capacidade { get; set; }
    }
}
