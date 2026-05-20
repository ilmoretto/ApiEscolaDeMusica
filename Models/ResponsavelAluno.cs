using AppEscolaDeMusica.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscolaDeMusica.Models
{
    public class ResponsavelAluno
    {
        [Column("parentesco")]
        public ParentescoEnum Parentesco { get; set; }
    }
}
