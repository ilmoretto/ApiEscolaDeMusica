using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
namespace AppEscolaDeMusica.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public required string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        [Column("fk_id_responsavel")]
        public int ResponsavelId { get; set; }
        public DateTime DataMatricula { get; set; }
        public StatusAlunoEnum StatusAluno { get; set; }

        [ForeignKey("ResponsavelId")]
        public ResponsavelAluno Responsavel { get; set; }

        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
        
        public ICollection<Agenda> Agendas { get; set; } = new List<Agenda>();
    }
}
