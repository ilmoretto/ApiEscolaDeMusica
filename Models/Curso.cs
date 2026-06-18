using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public NivelCursoEnum Nivel { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required string Instrumento { get; set; }
        public required int CargaHoraria { get; set; }
        public required int DuracaoMeses { get; set; }

        public ICollection<Turma>? Turmas { get; set; }

        public ICollection<Contrato>? Contratos { get; set; }
    }
}
