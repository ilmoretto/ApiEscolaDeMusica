namespace AppEscolaDeMusica.Dtos.Ministras
{
    public class MinistraCreateDto
    {
        public int TurmaId { get; set; }
        public int ProfessorId { get; set; }
        public required DateOnly DataAtribuicao { get; set; }
    }
}
