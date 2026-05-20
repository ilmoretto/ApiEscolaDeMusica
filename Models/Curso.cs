using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("curso"), PrimaryKey(nameof(Id))]
    public class Curso
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nivel")]
        public NivelCursoEnum Nivel { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }

        [Column("instrumento")]
        public required string Instrumento { get; set; }

        [Column("carga_horaria")]
        public required int CargaHoraria { get; set; }

        [Column("duracao_meses")]
        public required int DuracaoMeses { get; set; }

        public ICollection<Turma>? Turmas { get; set; }

        public ICollection<Contrato>? Contratos { get; set; }
    }
}
