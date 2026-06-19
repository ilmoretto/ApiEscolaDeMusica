using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public StatusTurmaEnum StatusTurma { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
        public required TimeOnly HorarioInicio { get; set; }
        public required TimeOnly HorarioFim { get; set; }
        public required int Capacidade { get; set; }
        public required int QuantidadeAulas { get; set; }
        public required DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; }

        public ICollection<Ministra> Ministras { get; set; } = new List<Ministra>();
        
        public ICollection<Agenda> Agendas { get; set; } = new List<Agenda>();
    }
}
