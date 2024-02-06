using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Autoplay.DataTransfer.Fornecedores.Request
{
    public class FornecedorInseriRequest
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int TipoFornecedor { get; set; }
    }
}