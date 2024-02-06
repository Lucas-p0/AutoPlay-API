using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Repositorios.Filtros
{
    public class FornecedorListarFiltro
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int TipoFornecedor { get; set; }
    }
}