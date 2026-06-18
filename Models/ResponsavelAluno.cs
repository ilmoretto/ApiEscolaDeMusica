using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Models
{
    public class ResponsavelAluno
    {
        public int Id { get; set; }
        public required string Cpf { get; set; }
        public required string Rg { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public ParentescoEnum Parentesco { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
