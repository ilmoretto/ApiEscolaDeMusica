namespace AppEscolaDeMusica.DTOs.Ministras
{
    public class MinistraUpdateDto
    {
        public int TurmaId { get; set; }
        public int ProfessorId { get; set; }
        public required DateOnly DataAtribuicao { get; set; }
    }
}
