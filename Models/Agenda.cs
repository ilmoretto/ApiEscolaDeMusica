using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    public class Agenda
    {
        [Column("status_agenda")]
        public StatusAgendaEnum StatusAgenda { get; set; }
    }
}
