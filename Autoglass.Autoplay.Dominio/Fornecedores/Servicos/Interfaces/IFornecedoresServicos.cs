using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Fornecedores.Entidades;
using Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Comandos;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServicos
    {
        Fornecedor Inserir(FornecedorInserirComando comando);
        Fornecedor Editar(FornecedorEditarComando comando);
        Fornecedor Validar(int id);
        Fornecedor Instanciar(FornecedorInserirComando comando);
    }

}