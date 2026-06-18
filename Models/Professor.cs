using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    public class Professor
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Cpf { get; set; }

        public required string Rg { get; set; }

        public string Email { get; set; }

        public required string Telefone { get; set; }

        public required DateOnly DataAdmissao { get; set; }

        public DateOnly? DataDemissao { get; set; }

        public StatusProfessorEnum StatusProf { get; set; }

        public required string Especialidade { get; set; }

        public required decimal ValorHoraAula { get; set; }

        public ICollection<Ministra> Ministras { get; set; } = new List<Ministra>();        
        public ICollection<DisponibilidadeProfessor> Disponibilidades { get; set; } = new List<DisponibilidadeProfessor>();
    }
}
