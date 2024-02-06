using Autoglass.Autoplay.Aplicacao.Artistas.Servicos.Interfaces;
using Autoglass.Autoplay.Aplicacao.Utils.Transacoes.Interfaces;
using Autoglass.Autoplay.DataTransfer.Artistas.Request;
using Autoglass.Autoplay.DataTransfer.Artistas.Response;
using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Artistas.Servicos.Comandos;
using Autoglass.Autoplay.Dominio.Artistas.Servicos.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Autoglass.Autoplay.Aplicacao.Artistas.Servicos
{
    public class ArtistasAppServico : IArtistasAppServico
    {
        private readonly IArtistasServico artistasServico;
        private readonly IArtistasRepositorio artistasRepositorio;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ArtistasAppServico> logger;

        public ArtistasAppServico(IArtistasServico artistasServico, IArtistasRepositorio artistasRepositorio, IMapper mapper, IUnitOfWork unitOfWork, ILogger<ArtistasAppServico> logger)
        {
            this.artistasServico = artistasServico;
            this.artistasRepositorio = artistasRepositorio;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public ArtistaResponse Editar(int id, ArtistaRequest request)
        {
            ArtistaComando comando = mapper.Map<ArtistaComando>(request);
            comando.Id = id;
            try
            {
                unitOfWork.BeginTransaction();

                Artista artista = artistasServico.Editar(comando);

                unitOfWork.Commit();

                return mapper.Map<ArtistaResponse>(artista);
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();

                logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "ArtistasAppServico", "Editar", "Artista");

                throw;
            }
        }

        public void Excluir(int id)
        {
            Artista artista = artistasServico.Validar(id);
            try
            {
                unitOfWork.BeginTransaction();
                artistasRepositorio.Inativar(artista);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "ArtistasAppServico", "Excluir", "Artista");
                throw;
            }
        }

        public ArtistaResponse Inserir(ArtistaRequest request)
        {
            ArtistaComando comando = mapper.Map<ArtistaComando>(request);
            try
            {
                unitOfWork.BeginTransaction();

                Artista artista = artistasServico.Inserir(comando);

                unitOfWork.Commit();

                return mapper.Map<ArtistaResponse>(artista);
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();

                logger.LogError(ex, "<{EventId}> | Erro ao <{Acao}> | entidade <{Entidade}> ", "ArtistasAppServico", "Inserir", "Artista");

                throw;
            }
        }

        public PaginacaoConsulta<ArtistaResponse> Listar(ArtistaListarRequest request)
        {
            ArtistaListarFiltro filtro = mapper.Map<ArtistaListarFiltro>(request);

            IQueryable<Artista> query = artistasRepositorio.Filtrar(filtro);

            PaginacaoConsulta<Artista> artistas = artistasRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            return mapper.Map<PaginacaoConsulta<ArtistaResponse>>(artistas);
        }

        public ArtistaResponse Recuperar(int id)
        {
            Artista artista = artistasServico.Validar(id);
            return mapper.Map<ArtistaResponse>(artista);
        }
    }
}