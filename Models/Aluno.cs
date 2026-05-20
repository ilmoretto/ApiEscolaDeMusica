using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
namespace AppEscolaDeMusica.Models
{
    [Table("aluno")]
    public class Aluno
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("rg")]
        public string Rg { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("fk_id_responsavel")]
        public int ResponsavelId { get; set; }

        [Column("data_matricula")]
        public DateTime DataMatricula { get; set; }

        [Column("status_aluno")]
        public StatusAlunoEnum StatusAluno { get; set; }

        [ForeignKey("ResponsavelId")]
        public ResponsavelAluno Responsavel { get; set; }

        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
