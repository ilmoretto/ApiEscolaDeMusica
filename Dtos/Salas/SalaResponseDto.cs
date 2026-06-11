namespace AppEscolaDeMusica.Dtos.Salas
{
    public class SalaResponseDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Localizacao { get; set; }
        public required int Capacidade { get; set; }
    }
}
