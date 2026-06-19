namespace AppEscolaDeMusica.Dtos.Salas
{
    public class SalaResponseDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Localizacao { get; set; }
        public required string Equipamentos { get; set; }
        public int Capacidade { get; set; }
    }
}