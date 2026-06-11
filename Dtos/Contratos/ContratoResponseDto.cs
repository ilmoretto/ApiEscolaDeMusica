using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Dtos.Contratos
{
    public class ContratoResponseDto
    {
        public int Id { get; set; }
        public required DateOnly DataInicio { get; set; }
        public required DateOnly DataFim { get; set; }
        public required decimal ValorMensal { get; set; }
        public StatusContratoEnum StatusContrato { get; set; }
        public required int AlunoId { get; set; }
        public required int CursoId { get; set; }
    }
}
