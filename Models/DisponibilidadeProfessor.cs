using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    public class DisponibilidadeProfessor
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
        public TimeOnly HorarioInicio { get; set; }
        public TimeOnly HorarioFim { get; set; }
        public StatusDisponibilidadeEnum StatusDisp { get; set; }

        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }
    }
}
