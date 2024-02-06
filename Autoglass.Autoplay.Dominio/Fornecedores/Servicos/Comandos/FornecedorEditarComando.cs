using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Fornecedores.Enumeradores;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Comandos
{
    public class FornecedorEditarComando
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public TipoFornecedorEnum TipoFornecedor { get; set; }
    }
}