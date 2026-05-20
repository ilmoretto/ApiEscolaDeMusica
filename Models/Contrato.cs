using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("contrato"), PrimaryKey(nameof(Id))]
    public class Contrato
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("data_inicio")]
        public required DateOnly DataInicio { get; set; }

        [Column("data_fim")]
        public required DateOnly DataFim { get; set; }

        [Column("Data_vencimento")]
        public required DateOnly DataVencimento { get; set; }

        [Column("valor_mensal")]
        public required decimal ValorMensal { get; set; }

        [Column("status_contrato")]
        public StatusContratoEnum StatusContrato { get; set; }

        [Column("fk_aluno_id")]
        public required int AlunoId { get; set; }
        public virtual Aluno? Aluno { get; set; }

        [Column("fk_curso_id")]
        public required int CursoId { get; set; }
        public virtual Curso? Curso { get; set; }

    }
}
