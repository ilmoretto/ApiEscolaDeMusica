using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    [Table("sala"), PrimaryKey(nameof(Id))]
    public class Sala
    {
        [Column ("id")]
        public int Id { get; set; }

        [Column ("nome")]
        public required string Nome { get; set; }

        [Column ("localizacao")]
        public required string Localizacao { get; set; }

        [Column ("equipamentos")]
        public required string Equipamentos { get; set; }

        [Column ("capacidade")]
        public required int Capacidade { get; set; }

        public ICollection<Turma>? Turmas { get; set; } 
    }
}
