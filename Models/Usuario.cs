using System.ComponentModel.DataAnnotations.Schema;
using AppEscolaDeMusica.Enums;

namespace AppEscolaDeMusica.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string Senha { get; set; }
        public RoleEnum Role { get; set; }
    }
}
