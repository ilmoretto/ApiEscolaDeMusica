using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    public class Professor
    {
        [Column("status_prof")]
        public StatusProfessorEnum StatusProf { get; set; }
    }
}
