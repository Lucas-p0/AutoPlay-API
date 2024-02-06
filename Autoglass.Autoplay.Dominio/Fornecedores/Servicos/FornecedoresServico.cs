using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Fornecedores.Entidades;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios;
using Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Comandos;
using Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Servicos
{
    public class FornecedoresServico : IFornecedoresServicos
    {
        private readonly IFonecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresServico(IFonecedoresRepositorio fornecedoresRepositorio)
        {
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }

        public Fornecedor Editar(FornecedorEditarComando comando)
        {
            Fornecedor fornecedor = Validar(comando.Id);
            fornecedor.SetCnpj(comando.Cnpj);
            fornecedor.SetNome(comando.Nome);
            fornecedor.SetTipoFornecedor(comando.TipoFornecedor);
            fornecedoresRepositorio.Editar(fornecedor);
            return fornecedor;
        }

        public Fornecedor Inserir(FornecedorInserirComando comando)
        {
            Fornecedor fornecedor = Instanciar(comando);
            fornecedoresRepositorio.Inserir(fornecedor);
            return fornecedor;
        }
        public Fornecedor Instanciar(FornecedorInserirComando comando)
        {
            return new Fornecedor(comando.Nome, comando.Cnpj, comando.TipoFornecedor);
        }

        public Fornecedor Validar(int id)
        {
            Fornecedor fornecedor = fornecedoresRepositorio.Recuperar(id);
            if (fornecedor is null)
            {
                throw new RegraDeNegocioExcecao("Fornecedor não encontrado");
            }
            return fornecedor;
        }
    }
}