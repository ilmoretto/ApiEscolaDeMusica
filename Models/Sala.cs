using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Localizacao { get; set; }
        public required string Equipamentos { get; set; }
        public required int Capacidade { get; set; }

        public ICollection<Turma>? Turmas { get; set; } 
    }
}
