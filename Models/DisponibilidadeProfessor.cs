using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    public class DisponibilidadeProfessor
    {
        [Column("dia_semana")]
        public DiaSemanaEnum DiaSemana { get; set; }
        [Column("status_disp")]
        public StatusDisponibilidadeEnum StatusDisp { get; set; }


    }
}
