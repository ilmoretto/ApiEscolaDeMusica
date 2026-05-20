using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("responsavel_aluno")]
    public class ResponsavelAluno
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("cpf")]
        public required string Cpf { get; set; }

        [Column("rg")]
        public required string Rg { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("parentesco")]
        public ParentescoEnum Parentesco { get; set; }

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
