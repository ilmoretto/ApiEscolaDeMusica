using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("professor")]
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
        public string Telefone { get; set; }

        [Column("data_admissao")]
        public DateTime? DataAdmissao { get; set; }

        [Column("data_demissao")]
        public DateTime? DataDemissao { get; set; }

        [Column("status_prof")]
        public StatusProfessorEnum StatusProf { get; set; }

        [Column("especialidade")]
        public string Especialidade { get; set; }

        [Column("valor_hora_aula")]
        public decimal ValorHoraAula { get; set; }

        public ICollection<Sala> Salas { get; set; } = new List<Sala>();
    }
}
