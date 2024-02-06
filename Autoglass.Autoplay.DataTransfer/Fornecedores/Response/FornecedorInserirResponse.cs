using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Autoplay.DataTransfer.Fornecedores.Request.Response
{
    public class FornecedorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpnj { get; set; }
        public int TipoFornecedor { get; set; }
        public int Ativo { get; set; }
    }
}