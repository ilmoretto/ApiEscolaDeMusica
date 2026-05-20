using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("professor"), PrimaryKey(nameof(Id))]
    public class Professor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("cpf")]
        public required string Cpf { get; set; }

        [Column("rg")]
        public required string Rg { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public required string Telefone { get; set; }

        [Column("data_admissao")]
        public required DateOnly DataAdmissao { get; set; }

        [Column("data_demissao")]
        public DateOnly? DataDemissao { get; set; }

        [Column("status_prof")]
        public StatusProfessorEnum StatusProf { get; set; }

        [Column("especialidade")]
        public required string Especialidade { get; set; }

        [Column("valor_hora_aula")]
        public required decimal ValorHoraAula { get; set; }

        public ICollection<Ministra> Ministras { get; set; } = new List<Ministra>();
        
        public ICollection<DisponibilidadeProfessor> Disponibilidades { get; set; } = new List<DisponibilidadeProfessor>();
    }
}
