using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public required DateOnly DataInicio { get; set; }
        public required DateOnly DataFim { get; set; }
        public required DateOnly DataVencimento { get; set; }
        public required decimal ValorMensal { get; set; }
        public StatusContratoEnum StatusContrato { get; set; }
        public required int AlunoId { get; set; }
        public virtual Aluno? Aluno { get; set; }
        public required int CursoId { get; set; }
        public virtual Curso? Curso { get; set; }

    }
}
