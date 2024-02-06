using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Aplicacao.Fornecedores.Servicos.Interfaces;
using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.DataTransfer.Fornecedores.Request;
using Autoglass.Autoplay.DataTransfer.Fornecedores.Request.Response;
using Autoglass.Autoplay.Dominio.Fornecedores.Entidades;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Comandos;
using Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;

namespace Autoglass.Autoplay.Aplicacao.Fornecedores.Servicos
{
    public class FornecedoresAppServicos : IFornecedorAppServicos
    {
        private readonly IFornecedoresServicos fornecedoresServicos;
        private readonly IFonecedoresRepositorio fornecedoresRepositorios;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<FornecedoresAppServicos> logger;

        public FornecedoresAppServicos(IFornecedoresServicos fornecedoresServicos, IFonecedoresRepositorio fornecedoresRepositorios, IUnitOfWork unitOfWork, IMapper mapper, ILogger<FornecedoresAppServicos> logger)
        {
            this.fornecedoresServicos = fornecedoresServicos;
            this.fornecedoresRepositorios = fornecedoresRepositorios;
            this.UnitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request)
        {
            throw new NotImplementedException();
        }

        public FornecedorResponse Recuperar(Int id)
        {
            throw new NotImplementedException();
        }

        FornecedorResponse IFornecedorAppServicos.Inserir(FornecedorInserirRequest request)
        {
            FornecedorInserirComando comando = mapper.Map<FornecedorInserirComando>(request);
            try
            {
                UnitOfWork.BeginTransaction();
                Fornecedor fornecedor = fornecedoresServicos.Inserir(comando);
                UnitOfWork.Commit();
                return mapper.Map<FornecedorResponse>(fornecedor);
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "FornecedoresAppServico", "Inserir", "Artista");
                throw;
            }
        }
        public PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request)
        {
            FornecedorListarFiltro filtro = mapper.Map<FornecedorListarFiltro>(request);
            IQueryable<Fornecedor> fornecedores = fornecedoresRepositorios.Filtrar(filtro);
            PaginacaoConsulta<Fornecedor> fornecedor = fornecedoresRepositorios.Listar(query, request.)

        }
    }
}