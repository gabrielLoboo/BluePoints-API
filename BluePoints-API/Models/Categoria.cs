using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluePoints_API.Models
{
    [Table("T_CATEGORIA")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        public string Nome { get; set; }

        public ICollection<Premio> Premios { get; set; } = new List<Premio>();
    }
}

