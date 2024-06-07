using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BluePoints_API.Models
{
    [Table("T_PREMIO")]
    public class Premio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do premio é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do premio é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A quantidade de pontos do premio é obrigatório")]
        public int Pontos { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<UsuarioPremio> UsuarioPremios { get; set; } = new List<UsuarioPremio>();
    }
}
