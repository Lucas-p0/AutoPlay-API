using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.DataTransfer.Fornecedores.Request;
using Autoglass.Autoplay.DataTransfer.Fornecedores.Request.Response;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using NPOI.SS.Formula.Functions;

namespace Autoglass.Autoplay.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedorAppServicos
    {
        FornecedorResponse Inserir(FornecedorInserirRequest request);
        FornecedorResponse Recuperar(Int id);
        PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request);
    }

    internal class FornecedorInserirRequest
    {
    }
}