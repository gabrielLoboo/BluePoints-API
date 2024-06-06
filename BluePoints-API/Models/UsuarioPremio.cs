using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluePoints_API.Models
{
    [Table("T_USUARIO_PREMIO")]
    public class UsuarioPremio
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Premio")]
        public int PremioId { get; set; }
        public Premio Premio { get; set; }

        [Required(ErrorMessage = "A data de resgate do premio é obrigatório")]
        public DateTime DataResgate { get; set; }
    }
}