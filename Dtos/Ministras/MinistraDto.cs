namespace AppEscolaDeMusica.Dtos.Ministras
{
    public class MinistraDto
    {
        public int TurmaId { get; set; }
        public int ProfessorId { get; set; }
        public required DateOnly DataAtribuicao { get; set; }
    }
}
