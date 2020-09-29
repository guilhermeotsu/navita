using Nativa.Core.Model;
using System;

namespace Navita.Core.Model
{
    public class Patrimonio : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid? NTombo { get; set; }

        // RELACIONAMENTO
        public int MarcaId { get; set; }    
        public Marca Marca { get; set; }
    }
}
