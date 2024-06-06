using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BluePoints_API.Models
{
    [Table("T_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="O nome do usuário é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A quantidade de pontos que o usuário possui é obrigatório")]
        public int Pontos { get; set; }

        public ICollection<UsuarioPremio> UsuarioPremios { get; set; } = new List<UsuarioPremio>();
    }
}
