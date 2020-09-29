using System;
using System.ComponentModel.DataAnnotations;

namespace Nativa.API.ViewModel
{
    public class PatrimonioViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Descricao { get; set; }

        public Guid? NTombo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? MarcaId { get; set; }
    }
}
