namespace AppEscolaDeMusica.DTOs.Ministras
{
    public class MinistraResponseDto
    {
        public int TurmaId { get; set; }
        public int ProfessorId { get; set; }
        public required DateOnly DataAtribuicao { get; set; }
    }
}
